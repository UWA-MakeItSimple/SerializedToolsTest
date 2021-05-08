using UnityEngine;
using System.IO;

using FlatBuffers;
using Vest;

using NPOI;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

using UnityEngine.Profiling;
using System.Collections;

public class ReadExcelByFlatBuffers : MonoBehaviour
{
    static string NewLine = "\n";
    static string _excelPath = "./Assets/ExcelData";
    byte[] bytes;

    private void ReadExcelNPOIAndSave()
    {
        string[] files = Directory.GetFiles(_excelPath, "*.xlsx");
        foreach (string file in files)
        {
            string excelName = Path.GetFileNameWithoutExtension(file);
            // 正在编辑的Excel文件会生成一个临时文件，并以~$开头
            if (excelName.StartsWith("~$"))
                continue;

            XSSFWorkbook wk = new XSSFWorkbook(file);
            int count = wk.Count;
            for (int n = 0; n < count; ++n)
            {
                ISheet sheet = wk[n];
                string sheetName = sheet.SheetName;
                Debug.Log(sheetName);
                // 忽略描述页
                if (sheetName == "MATERIAL")
                {
                    int mRowNum = sheet.LastRowNum;
                    IRow datarow = sheet.GetRow(2);
                    int mCellNum = datarow.LastCellNum;


                    var builder = new FlatBufferBuilder(1);

                    var weaps = new Offset<Weapon>[mRowNum - 3];
                    for (int CurrentRow = 4; CurrentRow <= mRowNum; CurrentRow++)
                    {
                        var ID = builder.CreateString(sheet.GetRow(CurrentRow).GetCell(0).ToString());
                        var Type = builder.CreateString(sheet.GetRow(CurrentRow).GetCell(1).ToString());
                        var Part = builder.CreateString(sheet.GetRow(CurrentRow).GetCell(2).ToString());
                        short RareLevel = short.Parse(sheet.GetRow(CurrentRow).GetCell(3).ToString());
                        int StoreNum = int.Parse(sheet.GetRow(CurrentRow).GetCell(4).ToString());
                        short StackDrop = short.Parse(sheet.GetRow(CurrentRow).GetCell(5).ToString());
                        short LootScore = short.Parse(sheet.GetRow(CurrentRow).GetCell(6).ToString());
                        var NameIDS = builder.CreateString(sheet.GetRow(CurrentRow).GetCell(7).ToString());
                        var DescriptionIDS = builder.CreateString(sheet.GetRow(CurrentRow).GetCell(8).ToString());
                        var Icon = builder.CreateString(sheet.GetRow(CurrentRow).GetCell(9).ToString());
                        var Instance = builder.CreateString(sheet.GetRow(CurrentRow).GetCell(10).ToString());
                        //ushort FormulaID = ushort.Parse(sheet.GetRow(CurrentRow).GetCell(11).ToString());
                        //string DropKingdom = sheet.GetRow(CurrentRow).GetCell(12).ToString();
                        //string DropPage = sheet.GetRow(CurrentRow).GetCell(13).ToString();
                        //short CorpLevelLimit = short.Parse(sheet.GetRow(CurrentRow).GetCell(14).ToString());

                        var item = Weapon.CreateWeapon(builder, ID, Type, Part, RareLevel, StoreNum, StackDrop, LootScore, NameIDS, DescriptionIDS, Icon, Instance);
                        weaps[CurrentRow - 4] = item;
                    }

                    var weapons = Goods.CreateWeaponsVector(builder, weaps);
                    Goods.StartGoods(builder);
                    Goods.AddWeapons(builder, weapons);
                    var orc = Goods.EndGoods(builder);
                    builder.Finish(orc.Value);

                    using (var ms = new MemoryStream(builder.DataBuffer.Data, builder.DataBuffer.Position, builder.Offset))
                    {
                        File.WriteAllBytes("VestTired.txt", ms.ToArray());
                        Debug.Log("SAVED !");
                    }
                }
            }
        }
    }

    private void Init()
    {
        StartCoroutine(LoadData());
    }

    private void Load()
    {
        System.Diagnostics.Stopwatch stopwatch2 = new System.Diagnostics.Stopwatch();
        System.Diagnostics.Stopwatch stopwatch3 = new System.Diagnostics.Stopwatch();


        stopwatch2.Start();
        Profiler.BeginSample("new ByteBuffer()");
        ByteBuffer bb = new ByteBuffer(bytes);
        Profiler.EndSample();
        stopwatch2.Stop();

        System.TimeSpan timespan2 = stopwatch2.Elapsed;
        double milliseconds2 = timespan2.TotalMilliseconds;  //  总毫秒数
        Debug.Log("转换耗时：" + milliseconds2);


        //反序列化
        stopwatch3.Start();
        Profiler.BeginSample("Goods.GetRootAsGoods()");
        Goods data = Goods.GetRootAsGoods(bb);
        Profiler.EndSample();
        stopwatch3.Stop();

        System.TimeSpan timespan3 = stopwatch3.Elapsed;
        double milliseconds3 = timespan3.TotalMilliseconds;  //  总毫秒数
        Debug.Log("反序列化耗时：" + milliseconds3);
    }

    private void Start()
    {
        //ReadExcelNPOIAndSave();
        //Load();
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Init", GUILayout.Width(200), GUILayout.Height(200)))
        {
            Init();
        }
        if (GUILayout.Button("Load",GUILayout.Width(200), GUILayout.Height(200)))
        {
            Load();
        }
   
    }

    IEnumerator LoadData()
    {
        string sPath = Application.streamingAssetsPath + "/VestTired.txt";
        System.Diagnostics.Stopwatch stopwatch1 = new System.Diagnostics.Stopwatch();
        stopwatch1.Start();
        Profiler.BeginSample("File.ReadAllBytes()");
        WWW www = new WWW(sPath);
        Profiler.EndSample();
        stopwatch1.Stop();
        System.TimeSpan timespan1 = stopwatch1.Elapsed;
        double milliseconds1 = timespan1.TotalMilliseconds;  //  总毫秒数
        Debug.Log("加载耗时：" + milliseconds1);

        yield return www;

        System.Diagnostics.Stopwatch stopwatch2 = new System.Diagnostics.Stopwatch();
        stopwatch2.Start();
        Profiler.BeginSample("Evaluation()");
        bytes = www.bytes;
        Profiler.EndSample();
        stopwatch2.Stop();
        System.TimeSpan timespan2 = stopwatch2.Elapsed;
        double milliseconds2 = timespan2.TotalMilliseconds;  //  总毫秒数
        Debug.Log("赋值耗时：" + milliseconds2);
    }
}

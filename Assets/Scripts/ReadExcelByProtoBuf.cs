using UnityEngine;
using System.IO;
using System.Collections;

using Protobuf;
using Google.Protobuf;

using NPOI;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;

using UnityEngine.Profiling;

public class ReadExcelByProtoBuf : MonoBehaviour
{
     string NewLine = "\n";
     string _excelPath = "./Assets/ExcelData";

    byte[] bytes;

    private  void ReadExcelNPOIAndSave()
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
                // 忽略描述页
                if (sheetName == "MATERIAL")
                {
                    int mRowNum = sheet.LastRowNum;
                    IRow datarow = sheet.GetRow(2);
                    int mCellNum = datarow.LastCellNum;

                    var mGoods = new Goods();

                    for (int CurrentRow = 4; CurrentRow <= mRowNum; CurrentRow++)
                    {
                        var ID = sheet.GetRow(CurrentRow).GetCell(0).ToString();
                        var Type = sheet.GetRow(CurrentRow).GetCell(1).ToString();
                        var Part = sheet.GetRow(CurrentRow).GetCell(2).ToString();
                        short RareLevel = short.Parse(sheet.GetRow(CurrentRow).GetCell(3).ToString());
                        int StoreNum = int.Parse(sheet.GetRow(CurrentRow).GetCell(4).ToString());
                        short StackDrop = short.Parse(sheet.GetRow(CurrentRow).GetCell(5).ToString());
                        short LootScore = short.Parse(sheet.GetRow(CurrentRow).GetCell(6).ToString());
                        var NameIDS = sheet.GetRow(CurrentRow).GetCell(7).ToString();
                        var DescriptionIDS = sheet.GetRow(CurrentRow).GetCell(8).ToString();
                        var Icon = sheet.GetRow(CurrentRow).GetCell(9).ToString();
                        var Instance = sheet.GetRow(CurrentRow).GetCell(10).ToString();
                        //ushort FormulaID = ushort.Parse(sheet.GetRow(CurrentRow).GetCell(11).ToString());
                        //string DropKingdom = sheet.GetRow(CurrentRow).GetCell(12).ToString();
                        //string DropPage = sheet.GetRow(CurrentRow).GetCell(13).ToString();
                        //short CorpLevelLimit = short.Parse(sheet.GetRow(CurrentRow).GetCell(14).ToString());

                        var item = new Weapon();
                        item.ID = ID;
                        item.Type = Type;
                        item.Part = Part;
                        item.RareLevel = RareLevel;
                        item.StoreNum = StoreNum;
                        item.StackDrop = StackDrop;
                        item.LootScore = LootScore;
                        item.NameIDS = NameIDS;
                        item.DescriptionIDS = DescriptionIDS;
                        item.Icon = Icon;
                        item.Instance = Instance;

                        mGoods.Weapons.Add(item);
                        mGoods.Weapons.Add(item);
                    }

                    using (var output = File.Create("john.dat"))
                    {
                        mGoods.WriteTo(output);
                    }
                    
                }
            }
        }
    }

    private void Load()
    {
        Goods data;
        System.Diagnostics.Stopwatch stopwatch2 = new System.Diagnostics.Stopwatch();
        Debug.Log(bytes.Length);
        //反序列化
        stopwatch2.Start();
        Profiler.BeginSample("Goods.Parser.ParseFrom()");
        data = Goods.Parser.ParseFrom(bytes);
        Profiler.EndSample();
        stopwatch2.Stop();

        System.TimeSpan timespan2 = stopwatch2.Elapsed;
        double milliseconds2 = timespan2.TotalMilliseconds;  //  总毫秒数
        Debug.Log("反序列化耗时：" + milliseconds2);
    }

    private void Init()
    {
        StartCoroutine(LoadData());
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
        if (GUILayout.Button("Load", GUILayout.Width(200), GUILayout.Height(200)))
        {
            Load();
        }
    }

    IEnumerator LoadData()
    {
        string sPath = Application.streamingAssetsPath + "/john.dat";
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

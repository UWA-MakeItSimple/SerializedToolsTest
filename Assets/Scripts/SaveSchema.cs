// automatically generated, do not modify

namespace Vest
{

using FlatBuffers;

public sealed class Goods : Table {
  public static Goods GetRootAsGoods(ByteBuffer _bb) { return GetRootAsGoods(_bb, new Goods()); }
  public static Goods GetRootAsGoods(ByteBuffer _bb, Goods obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public Goods __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public Weapon GetWeapons(int j) { return GetWeapons(new Weapon(), j); }
  public Weapon GetWeapons(Weapon obj, int j) { int o = __offset(4); return o != 0 ? obj.__init(__indirect(__vector(o) + j * 4), bb) : null; }
  public int WeaponsLength { get { int o = __offset(4); return o != 0 ? __vector_len(o) : 0; } }

  public static Offset<Goods> CreateGoods(FlatBufferBuilder builder,
      VectorOffset weapons = default(VectorOffset)) {
    builder.StartObject(1);
    Goods.AddWeapons(builder, weapons);
    return Goods.EndGoods(builder);
  }

  public static void StartGoods(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddWeapons(FlatBufferBuilder builder, VectorOffset weaponsOffset) { builder.AddOffset(0, weaponsOffset.Value, 0); }
  public static VectorOffset CreateWeaponsVector(FlatBufferBuilder builder, Offset<Weapon>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static void StartWeaponsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Goods> EndGoods(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Goods>(o);
  }
  public static void FinishGoodsBuffer(FlatBufferBuilder builder, Offset<Goods> offset) { builder.Finish(offset.Value); }
};

public sealed class Weapon : Table {
  public static Weapon GetRootAsWeapon(ByteBuffer _bb) { return GetRootAsWeapon(_bb, new Weapon()); }
  public static Weapon GetRootAsWeapon(ByteBuffer _bb, Weapon obj) { return (obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public Weapon __init(int _i, ByteBuffer _bb) { bb_pos = _i; bb = _bb; return this; }

  public string ID { get { int o = __offset(4); return o != 0 ? __string(o + bb_pos) : null; } }
  public string Type { get { int o = __offset(6); return o != 0 ? __string(o + bb_pos) : null; } }
  public string Part { get { int o = __offset(8); return o != 0 ? __string(o + bb_pos) : null; } }
  public short RareLevel { get { int o = __offset(10); return o != 0 ? bb.GetShort(o + bb_pos) : (short)0; } }
  public int StoreNum { get { int o = __offset(12); return o != 0 ? bb.GetInt(o + bb_pos) : (int)1; } }
  public short StackDrop { get { int o = __offset(14); return o != 0 ? bb.GetShort(o + bb_pos) : (short)0; } }
  public short LootScore { get { int o = __offset(16); return o != 0 ? bb.GetShort(o + bb_pos) : (short)0; } }
  public string NameIDS { get { int o = __offset(18); return o != 0 ? __string(o + bb_pos) : null; } }
  public string DescriptionIDS { get { int o = __offset(20); return o != 0 ? __string(o + bb_pos) : null; } }
  public string Icon { get { int o = __offset(22); return o != 0 ? __string(o + bb_pos) : null; } }
  public string Instance { get { int o = __offset(24); return o != 0 ? __string(o + bb_pos) : null; } }
  public ushort FormulaID { get { int o = __offset(26); return o != 0 ? bb.GetUshort(o + bb_pos) : (ushort)0; } }
  public string DropKingdom { get { int o = __offset(28); return o != 0 ? __string(o + bb_pos) : null; } }
  public string DropPage { get { int o = __offset(30); return o != 0 ? __string(o + bb_pos) : null; } }
  public short CorpLevelLimit { get { int o = __offset(32); return o != 0 ? bb.GetShort(o + bb_pos) : (short)1; } }

  public static Offset<Weapon> CreateWeapon(FlatBufferBuilder builder,
      StringOffset ID = default(StringOffset),
      StringOffset Type = default(StringOffset),
      StringOffset Part = default(StringOffset),
      short RareLevel = 0,
      int StoreNum = 1,
      short StackDrop = 0,
      short LootScore = 0,
      StringOffset NameIDS = default(StringOffset),
      StringOffset DescriptionIDS = default(StringOffset),
      StringOffset Icon = default(StringOffset),
      StringOffset Instance = default(StringOffset),
      ushort FormulaID = 0,
      StringOffset DropKingdom = default(StringOffset),
      StringOffset DropPage = default(StringOffset),
      short CorpLevelLimit = 1) {
    builder.StartObject(15);
    Weapon.AddDropPage(builder, DropPage);
    Weapon.AddDropKingdom(builder, DropKingdom);
    Weapon.AddInstance(builder, Instance);
    Weapon.AddIcon(builder, Icon);
    Weapon.AddDescriptionIDS(builder, DescriptionIDS);
    Weapon.AddNameIDS(builder, NameIDS);
    Weapon.AddStoreNum(builder, StoreNum);
    Weapon.AddPart(builder, Part);
    Weapon.AddType(builder, Type);
    Weapon.AddID(builder, ID);
    Weapon.AddCorpLevelLimit(builder, CorpLevelLimit);
    Weapon.AddFormulaID(builder, FormulaID);
    Weapon.AddLootScore(builder, LootScore);
    Weapon.AddStackDrop(builder, StackDrop);
    Weapon.AddRareLevel(builder, RareLevel);
    return Weapon.EndWeapon(builder);
  }

  public static void StartWeapon(FlatBufferBuilder builder) { builder.StartObject(15); }
  public static void AddID(FlatBufferBuilder builder, StringOffset IDOffset) { builder.AddOffset(0, IDOffset.Value, 0); }
  public static void AddType(FlatBufferBuilder builder, StringOffset TypeOffset) { builder.AddOffset(1, TypeOffset.Value, 0); }
  public static void AddPart(FlatBufferBuilder builder, StringOffset PartOffset) { builder.AddOffset(2, PartOffset.Value, 0); }
  public static void AddRareLevel(FlatBufferBuilder builder, short RareLevel) { builder.AddShort(3, RareLevel, 0); }
  public static void AddStoreNum(FlatBufferBuilder builder, int StoreNum) { builder.AddInt(4, StoreNum, 1); }
  public static void AddStackDrop(FlatBufferBuilder builder, short StackDrop) { builder.AddShort(5, StackDrop, 0); }
  public static void AddLootScore(FlatBufferBuilder builder, short LootScore) { builder.AddShort(6, LootScore, 0); }
  public static void AddNameIDS(FlatBufferBuilder builder, StringOffset NameIDSOffset) { builder.AddOffset(7, NameIDSOffset.Value, 0); }
  public static void AddDescriptionIDS(FlatBufferBuilder builder, StringOffset DescriptionIDSOffset) { builder.AddOffset(8, DescriptionIDSOffset.Value, 0); }
  public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset) { builder.AddOffset(9, IconOffset.Value, 0); }
  public static void AddInstance(FlatBufferBuilder builder, StringOffset InstanceOffset) { builder.AddOffset(10, InstanceOffset.Value, 0); }
  public static void AddFormulaID(FlatBufferBuilder builder, ushort FormulaID) { builder.AddUshort(11, FormulaID, 0); }
  public static void AddDropKingdom(FlatBufferBuilder builder, StringOffset DropKingdomOffset) { builder.AddOffset(12, DropKingdomOffset.Value, 0); }
  public static void AddDropPage(FlatBufferBuilder builder, StringOffset DropPageOffset) { builder.AddOffset(13, DropPageOffset.Value, 0); }
  public static void AddCorpLevelLimit(FlatBufferBuilder builder, short CorpLevelLimit) { builder.AddShort(14, CorpLevelLimit, 1); }
  public static Offset<Weapon> EndWeapon(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Weapon>(o);
  }
};


}

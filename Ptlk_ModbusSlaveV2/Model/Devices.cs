// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: devices.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Ptlk_ModbusSlaveV2.Model {

  /// <summary>Holder for reflection information generated from devices.proto</summary>
  public static partial class DevicesReflection {

    #region Descriptor
    /// <summary>File descriptor for devices.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static DevicesReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cg1kZXZpY2VzLnByb3RvEhhQdGxrX01vZGJ1c1NsYXZlVjIuTW9kZWwiuwEK",
            "BkRldmljZRIMCgRuYW1lGAEgASgJEgwKBHBvcnQYAiABKAUSCgoCaWQYAyAB",
            "KAUSOwoIZGF0YUl0ZW0YBCADKAsyKS5QdGxrX01vZGJ1c1NsYXZlVjIuTW9k",
            "ZWwuRGV2aWNlLkRhdGFJdGVtGkwKCERhdGFJdGVtEgwKBG5hbWUYASABKAkS",
            "DwoHYWRkcmVzcxgCIAEoBRINCgV2YWx1ZRgDIAEoBRISCgppc1ZvbGF0aWxl",
            "GAQgASgIIjsKB0RldmljZXMSMAoGZGV2aWNlGAEgAygLMiAuUHRsa19Nb2Ri",
            "dXNTbGF2ZVYyLk1vZGVsLkRldmljZUIbqgIYUHRsa19Nb2RidXNTbGF2ZVYy",
            "Lk1vZGVsYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Ptlk_ModbusSlaveV2.Model.Device), global::Ptlk_ModbusSlaveV2.Model.Device.Parser, new[]{ "Name", "Port", "Id", "DataItem" }, null, null, new pbr::GeneratedClrTypeInfo[] { new pbr::GeneratedClrTypeInfo(typeof(global::Ptlk_ModbusSlaveV2.Model.Device.Types.DataItem), global::Ptlk_ModbusSlaveV2.Model.Device.Types.DataItem.Parser, new[]{ "Name", "Address", "Value", "IsVolatile" }, null, null, null)}),
            new pbr::GeneratedClrTypeInfo(typeof(global::Ptlk_ModbusSlaveV2.Model.Devices), global::Ptlk_ModbusSlaveV2.Model.Devices.Parser, new[]{ "Device" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// [START messages]
  /// </summary>
  public sealed partial class Device : pb::IMessage<Device> {
    private static readonly pb::MessageParser<Device> _parser = new pb::MessageParser<Device>(() => new Device());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Device> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Ptlk_ModbusSlaveV2.Model.DevicesReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Device() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Device(Device other) : this() {
      name_ = other.name_;
      port_ = other.port_;
      id_ = other.id_;
      dataItem_ = other.dataItem_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Device Clone() {
      return new Device(this);
    }

    /// <summary>Field number for the "name" field.</summary>
    public const int NameFieldNumber = 1;
    private string name_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Name {
      get { return name_; }
      set {
        name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "port" field.</summary>
    public const int PortFieldNumber = 2;
    private int port_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Port {
      get { return port_; }
      set {
        port_ = value;
      }
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 3;
    private int id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "dataItem" field.</summary>
    public const int DataItemFieldNumber = 4;
    private static readonly pb::FieldCodec<global::Ptlk_ModbusSlaveV2.Model.Device.Types.DataItem> _repeated_dataItem_codec
        = pb::FieldCodec.ForMessage(34, global::Ptlk_ModbusSlaveV2.Model.Device.Types.DataItem.Parser);
    private readonly pbc::RepeatedField<global::Ptlk_ModbusSlaveV2.Model.Device.Types.DataItem> dataItem_ = new pbc::RepeatedField<global::Ptlk_ModbusSlaveV2.Model.Device.Types.DataItem>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Ptlk_ModbusSlaveV2.Model.Device.Types.DataItem> DataItem {
      get { return dataItem_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Device);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Device other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Name != other.Name) return false;
      if (Port != other.Port) return false;
      if (Id != other.Id) return false;
      if(!dataItem_.Equals(other.dataItem_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Name.Length != 0) hash ^= Name.GetHashCode();
      if (Port != 0) hash ^= Port.GetHashCode();
      if (Id != 0) hash ^= Id.GetHashCode();
      hash ^= dataItem_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Name.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Name);
      }
      if (Port != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Port);
      }
      if (Id != 0) {
        output.WriteRawTag(24);
        output.WriteInt32(Id);
      }
      dataItem_.WriteTo(output, _repeated_dataItem_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Name.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
      }
      if (Port != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Port);
      }
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Id);
      }
      size += dataItem_.CalculateSize(_repeated_dataItem_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Device other) {
      if (other == null) {
        return;
      }
      if (other.Name.Length != 0) {
        Name = other.Name;
      }
      if (other.Port != 0) {
        Port = other.Port;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      dataItem_.Add(other.dataItem_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Name = input.ReadString();
            break;
          }
          case 16: {
            Port = input.ReadInt32();
            break;
          }
          case 24: {
            Id = input.ReadInt32();
            break;
          }
          case 34: {
            dataItem_.AddEntriesFrom(input, _repeated_dataItem_codec);
            break;
          }
        }
      }
    }

    #region Nested types
    /// <summary>Container for nested types declared in the Device message type.</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static partial class Types {
      public sealed partial class DataItem : pb::IMessage<DataItem> {
        private static readonly pb::MessageParser<DataItem> _parser = new pb::MessageParser<DataItem>(() => new DataItem());
        private pb::UnknownFieldSet _unknownFields;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pb::MessageParser<DataItem> Parser { get { return _parser; } }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public static pbr::MessageDescriptor Descriptor {
          get { return global::Ptlk_ModbusSlaveV2.Model.Device.Descriptor.NestedTypes[0]; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        pbr::MessageDescriptor pb::IMessage.Descriptor {
          get { return Descriptor; }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public DataItem() {
          OnConstruction();
        }

        partial void OnConstruction();

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public DataItem(DataItem other) : this() {
          name_ = other.name_;
          address_ = other.address_;
          value_ = other.value_;
          isVolatile_ = other.isVolatile_;
          _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public DataItem Clone() {
          return new DataItem(this);
        }

        /// <summary>Field number for the "name" field.</summary>
        public const int NameFieldNumber = 1;
        private string name_ = "";
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public string Name {
          get { return name_; }
          set {
            name_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
          }
        }

        /// <summary>Field number for the "address" field.</summary>
        public const int AddressFieldNumber = 2;
        private int address_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Address {
          get { return address_; }
          set {
            address_ = value;
          }
        }

        /// <summary>Field number for the "value" field.</summary>
        public const int ValueFieldNumber = 3;
        private int value_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int Value {
          get { return value_; }
          set {
            value_ = value;
          }
        }

        /// <summary>Field number for the "isVolatile" field.</summary>
        public const int IsVolatileFieldNumber = 4;
        private bool isVolatile_;
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool IsVolatile {
          get { return isVolatile_; }
          set {
            isVolatile_ = value;
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override bool Equals(object other) {
          return Equals(other as DataItem);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public bool Equals(DataItem other) {
          if (ReferenceEquals(other, null)) {
            return false;
          }
          if (ReferenceEquals(other, this)) {
            return true;
          }
          if (Name != other.Name) return false;
          if (Address != other.Address) return false;
          if (Value != other.Value) return false;
          if (IsVolatile != other.IsVolatile) return false;
          return Equals(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override int GetHashCode() {
          int hash = 1;
          if (Name.Length != 0) hash ^= Name.GetHashCode();
          if (Address != 0) hash ^= Address.GetHashCode();
          if (Value != 0) hash ^= Value.GetHashCode();
          if (IsVolatile != false) hash ^= IsVolatile.GetHashCode();
          if (_unknownFields != null) {
            hash ^= _unknownFields.GetHashCode();
          }
          return hash;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public override string ToString() {
          return pb::JsonFormatter.ToDiagnosticString(this);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void WriteTo(pb::CodedOutputStream output) {
          if (Name.Length != 0) {
            output.WriteRawTag(10);
            output.WriteString(Name);
          }
          if (Address != 0) {
            output.WriteRawTag(16);
            output.WriteInt32(Address);
          }
          if (Value != 0) {
            output.WriteRawTag(24);
            output.WriteInt32(Value);
          }
          if (IsVolatile != false) {
            output.WriteRawTag(32);
            output.WriteBool(IsVolatile);
          }
          if (_unknownFields != null) {
            _unknownFields.WriteTo(output);
          }
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public int CalculateSize() {
          int size = 0;
          if (Name.Length != 0) {
            size += 1 + pb::CodedOutputStream.ComputeStringSize(Name);
          }
          if (Address != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Address);
          }
          if (Value != 0) {
            size += 1 + pb::CodedOutputStream.ComputeInt32Size(Value);
          }
          if (IsVolatile != false) {
            size += 1 + 1;
          }
          if (_unknownFields != null) {
            size += _unknownFields.CalculateSize();
          }
          return size;
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(DataItem other) {
          if (other == null) {
            return;
          }
          if (other.Name.Length != 0) {
            Name = other.Name;
          }
          if (other.Address != 0) {
            Address = other.Address;
          }
          if (other.Value != 0) {
            Value = other.Value;
          }
          if (other.IsVolatile != false) {
            IsVolatile = other.IsVolatile;
          }
          _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
        }

        [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
        public void MergeFrom(pb::CodedInputStream input) {
          uint tag;
          while ((tag = input.ReadTag()) != 0) {
            switch(tag) {
              default:
                _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
                break;
              case 10: {
                Name = input.ReadString();
                break;
              }
              case 16: {
                Address = input.ReadInt32();
                break;
              }
              case 24: {
                Value = input.ReadInt32();
                break;
              }
              case 32: {
                IsVolatile = input.ReadBool();
                break;
              }
            }
          }
        }

      }

    }
    #endregion

  }

  public sealed partial class Devices : pb::IMessage<Devices> {
    private static readonly pb::MessageParser<Devices> _parser = new pb::MessageParser<Devices>(() => new Devices());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Devices> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Ptlk_ModbusSlaveV2.Model.DevicesReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Devices() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Devices(Devices other) : this() {
      device_ = other.device_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Devices Clone() {
      return new Devices(this);
    }

    /// <summary>Field number for the "device" field.</summary>
    public const int DeviceFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Ptlk_ModbusSlaveV2.Model.Device> _repeated_device_codec
        = pb::FieldCodec.ForMessage(10, global::Ptlk_ModbusSlaveV2.Model.Device.Parser);
    private readonly pbc::RepeatedField<global::Ptlk_ModbusSlaveV2.Model.Device> device_ = new pbc::RepeatedField<global::Ptlk_ModbusSlaveV2.Model.Device>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Ptlk_ModbusSlaveV2.Model.Device> Device {
      get { return device_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Devices);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Devices other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!device_.Equals(other.device_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= device_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      device_.WriteTo(output, _repeated_device_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += device_.CalculateSize(_repeated_device_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Devices other) {
      if (other == null) {
        return;
      }
      device_.Add(other.device_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            device_.AddEntriesFrom(input, _repeated_device_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
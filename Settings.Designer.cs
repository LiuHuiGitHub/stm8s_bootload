﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace stm8s_bootload {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0x12,0x12,0x12,0x12,0x12,0x12,0x12,0x12,0x12,0x13")]
        public string readyCmd {
            get {
                return ((string)(this["readyCmd"]));
            }
            set {
                this["readyCmd"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0x3b,0x00,0x08,0xae,0x03,0xff,0x94,0xa6,0xac,0xcd,0x00,0x6c,0x3f,0x00,0x20,0x04,\r" +
            "\n0x35,0x01,0x00,0x00,0x3f,0x08,0x5f,0x35,0xaa,0x50,0xe0,0x72,0x0b,0x52,0x30,0xf7" +
            ",\r\n0xc6,0x52,0x31,0xa1,0xaa,0x27,0xe9,0xa1,0xcc,0x26,0x0b,0x3d,0x00,0x27,0xe8,0x" +
            "cd,\r\n0x01,0x09,0x3f,0x00,0x20,0xe0,0x3d,0x00,0x27,0xdd,0x3d,0x08,0x27,0x14,0xa4," +
            "0x0f,\r\n0xb7,0x01,0x4e,0xba,0x01,0x3f,0x08,0xd7,0x03,0x60,0x5c,0xa3,0x00,0x8a,0x2" +
            "5,0xc7,\r\n0x20,0xc4,0xa1,0xee,0x26,0xf1,0x35,0x01,0x00,0x08,0x20,0xbb,0x9d,0x9d,0" +
            "x9d,0x9d,\r\n0xc7,0x52,0x31,0x72,0x0d,0x52,0x30,0xfb,0x9d,0x9d,0x9d,0x9d,0x81,0x72" +
            ",0x13,0x50,\r\n0x5f,0x81,0x92,0xbd,0x00,0x01,0x81,0x90,0x93,0x72,0x1c,0x50,0x5b,0x" +
            "72,0x1d,0x50,\r\n0x5c,0x35,0x04,0x00,0x00,0xcd,0x00,0xab,0x4a,0xb7,0x00,0x26,0xf8," +
            "0x72,0x0d,0x50,\r\n0x5f,0xfb,0x72,0x1d,0x50,0x5b,0x72,0x1c,0x50,0x5c,0x81,0x90,0xf" +
            "6,0x92,0xbd,0x00,\r\n0x01,0x90,0x5c,0xcd,0x00,0xb9,0xb6,0x00,0x81,0x5f,0x5c,0x72,0" +
            "xbb,0x00,0x02,0xbf,\r\n0x02,0x81,0xcd,0x00,0xc6,0x81,0x35,0x56,0x50,0x62,0x35,0xae" +
            ",0x50,0x62,0x81,0x90,\r\n0x93,0x5f,0x97,0x58,0x58,0x58,0x58,0x58,0x58,0x58,0x58,0x" +
            "bf,0x00,0x51,0x01,0xb8,\r\n0x01,0x01,0xb8,0x00,0x01,0x51,0x35,0x08,0x00,0x00,0x93," +
            "0x58,0x51,0x02,0xa4,0x80,\r\n0x02,0x4f,0x02,0x51,0x90,0x5d,0x27,0x07,0x02,0xa8,0x1" +
            "6,0x02,0xa8,0x21,0x02,0x90,\r\n0x93,0xb6,0x00,0x4a,0xb7,0x00,0x26,0xe2,0x81,0x90,0" +
            "x5f,0x3f,0x03,0x3f,0x02,0x20,\r\n0x0f,0x1c,0x03,0x62,0xf6,0x93,0xcd,0x00,0xcf,0x90" +
            ",0x93,0xbe,0x02,0x5c,0xbf,0x02,\r\n0xce,0x03,0x62,0x1c,0x00,0x08,0xbf,0x00,0xbe,0x" +
            "02,0xb3,0x00,0x25,0xe3,0x90,0xc3,\r\n0x03,0x60,0x27,0x03,0xcc,0x02,0x2b,0xc6,0x03," +
            "0x65,0xa1,0xfe,0x26,0x2d,0xc6,0x03,\r\n0x6e,0xa1,0xaa,0x26,0x18,0xcd,0x00,0xc6,0xa" +
            "e,0x03,0x6a,0x90,0x93,0xae,0x9f,0xf8,\r\n0xcd,0x02,0x48,0xa6,0xa5,0xbd,0x00,0x9f,0" +
            "xf7,0x72,0x13,0x50,0x5f,0xa6,0xab,0xcd,\r\n0x00,0x6c,0x72,0x5f,0x52,0x35,0xac,0x00" +
            ",0x9f,0xf8,0x81,0xa1,0xf5,0x26,0x05,0xac,\r\n0x00,0x9f,0xfc,0x81,0xae,0x03,0x6a,0x" +
            "bf,0x06,0x20,0x3a,0xb6,0x05,0x4c,0xb7,0x05,\r\n0xc6,0x03,0x64,0xb7,0x00,0xb6,0x05," +
            "0xb1,0x00,0x24,0x16,0x5f,0x41,0x92,0xc6,0x06,\r\n0xd7,0x02,0xe0,0xbe,0x06,0x5c,0xb" +
            "f,0x06,0xce,0x03,0x62,0x5a,0xcf,0x03,0x62,0x26,\r\n0xda,0xb6,0x00,0xcd,0x02,0x30,0" +
            "xcd,0x02,0x51,0xc6,0x03,0x64,0x5f,0x97,0xcd,0x02,\r\n0x7b,0x72,0x13,0x50,0x5f,0xce" +
            ",0x03,0x62,0xa3,0x00,0x01,0x2f,0x69,0xc6,0x03,0x64,\r\n0xae,0x03,0x66,0xcd,0x02,0x" +
            "bf,0xb7,0x05,0xc6,0x03,0x64,0xcd,0x02,0x30,0xcd,0x02,\r\n0xa0,0xcd,0x00,0xc6,0xcd," +
            "0x02,0x33,0xbe,0x00,0x26,0x05,0xbe,0x02,0xa3,0x80,0x00,\r\n0x26,0x9e,0xa6,0xff,0xb" +
            "d,0x00,0x9f,0xf7,0x3f,0x04,0xc6,0x03,0x64,0x44,0x44,0xb7,\r\n0x00,0xb6,0x04,0xb1,0" +
            "x00,0x24,0xba,0x3d,0x04,0x27,0x0e,0xbe,0x06,0x90,0x93,0x5f,\r\n0x41,0x58,0x58,0x1c" +
            ",0x80,0x00,0xcd,0x02,0x48,0xbe,0x06,0x1c,0x00,0x04,0xbf,0x06,\r\n0xae,0x00,0x04,0x" +
            "cd,0x02,0x7b,0xce,0x03,0x62,0x1c,0xff,0xfc,0xcf,0x03,0x62,0xb6,\r\n0x04,0x4c,0xb7," +
            "0x04,0x20,0xc4,0xa6,0xa7,0xcc,0x00,0x6c,0xa6,0xad,0xcc,0x00,0x6c,\r\n0xae,0x02,0xe" +
            "0,0x55,0x03,0x66,0x00,0x00,0x55,0x03,0x67,0x00,0x01,0x55,0x03,0x68,\r\n0x00,0x02,0" +
            "x55,0x03,0x69,0x00,0x03,0x81,0xbf,0x02,0x5f,0xbf,0x00,0x93,0xcc,0x00,\r\n0x87,0x90" +
            ",0x93,0xb7,0x04,0x72,0x10,0x50,0x5b,0x72,0x11,0x50,0x5c,0x3f,0x00,0x20,\r\n0x06,0x" +
            "cd,0x00,0xab,0x4c,0xb7,0x00,0xb6,0x00,0xb1,0x04,0x25,0xf4,0x72,0x0d,0x50,\r\n0x5f," +
            "0xfb,0x72,0x11,0x50,0x5b,0x72,0x10,0x50,0x5c,0x81,0xbf,0x02,0x5f,0xbf,0x00,\r\n0xa" +
            "e,0x03,0x66,0xd6,0x00,0x03,0xbb,0x03,0xd7,0x00,0x03,0xd6,0x00,0x02,0xb9,0x02,\r\n0" +
            "xd7,0x00,0x02,0xd6,0x00,0x01,0xb9,0x01,0xd7,0x00,0x01,0xf6,0xb9,0x00,0xf7,0x81,\r" +
            "\n0x90,0x93,0xb7,0x04,0x3f,0x00,0x20,0x10,0x92,0xbc,0x00,0x01,0x90,0xf7,0xcd,0x00" +
            ",\r\n0xb9,0x90,0x5c,0xb6,0x00,0x4c,0xb7,0x00,0xb6,0x00,0xb1,0x04,0x25,0xea,0x81,0x" +
            "4a,\r\n0xb7,0x00,0x1c,0x00,0x03,0xf6,0xb7,0x02,0xb6,0x00,0xb4,0x02,0xb7,0x01,0x33," +
            "0x00,\r\n0xb6,0x00,0xb4,0x02,0xf7,0xb6,0x01,0x81,0xaa,0xcc")]
        public string boot {
            get {
                return ((string)(this["boot"]));
            }
            set {
                this["boot"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("115200")]
        public string baud {
            get {
                return ((string)(this["baud"]));
            }
            set {
                this["baud"] = value;
            }
        }
    }
}

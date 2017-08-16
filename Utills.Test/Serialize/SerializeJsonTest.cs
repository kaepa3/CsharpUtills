using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.Serialization;
namespace Utills.Serialize.Test
{
    [TestClass]
    public class SerializeJsonTest
    {
        [TestMethod]
        public void Jsonシリアライズ()
        {
            var obj = new SerializeJson();
            var dat = new SampleClass() { Hoge = "nanzo", Nemu = 2, Maker = 5};
            string testPath = "making.json";
            obj.Write(dat, testPath);
            var readObj = obj.Read<SampleClass>(testPath);
            readObj.Hoge.Is(dat.Hoge);
            readObj.Nemu.Is(dat.Nemu);
            readObj.Maker.Is(0);
        }

        /// <summary>
        /// JsonRead確認用クラス
        /// </summary>
        [DataContract, Serializable]

        public class SampleClass
        {

            [DataMember()]
            public string Hoge;

            int nemu;
            [System.Runtime.Serialization.DataMember()]
            public int Nemu {
                get { return nemu; }
                set
                {
                    nemu = value;
                }
            }

            public int Maker;
        }




    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using generator;

namespace TestGenerator.Tests
{
    [TestClass()]
    public class UnitTest1Tests
    {
        [TestMethod()]
        public void Test1()
        {
            bool flag = true;
            BGgen g1 = new BGgen("D:\\CharGenerator\\result\\f.txt");
            if (g1.bg[2, 3] != 20 || g1.bg[11, 18] != 6 || g1.bg[19, 5] != 2)
                flag = false;
            Assert.IsTrue(flag == true);
        }
        [TestMethod]
        public void Test2()
        {
            bool flag = true;
            HalfWordgen g2 = new HalfWordgen("D:\\CharGenerator\\result\\s.txt");
            if (g2.raw[31] != 442198 || g2.raw[92] != 160363 || g2.words[6] != "он" || g2.words[64] != "я")
                flag = false;
            Assert.IsTrue(flag == true);
        }
        [TestMethod]
        public void Test3()
        {
            bool flag = true;
            TwoWordgen g3 = new TwoWordgen("D:\\CharGenerator\\result\\t.txt");
            if (g3.raw[23] != 67202 || g3.raw[59] != 40259 || g3.words[17, 0] != "я" || g3.words[96, 1] != "нет")
                flag = false;
            Assert.IsTrue(flag == true);
        }
        [TestMethod]
        public void Test4()
        {
            char str = '1';
            string text;
            BGgen g1 = new BGgen("D:\\CharGenerator\\result\\f.txt");
            using (StreamWriter w = new StreamWriter("D:\\CharGenerator\\result\\1.txt"))
            {

                for (int i = 0; i < 20; i++)
                {
                    str = g1.Sym(str);
                    w.Write(str);
                }
            }
            using (StreamReader f = new StreamReader("D:\\CharGenerator\\result\\1.txt"))
            {
                text = f.ReadLine();
            }
            Assert.IsTrue(text.Length == 20);
        }
        [TestMethod]
        public void Test5()
        {
            string slovo;
            string text;
            int k = 0;
            HalfWordgen g2 = new HalfWordgen("D:\\CharGenerator\\result\\s.txt");
            using (StreamWriter w = new StreamWriter("D:\\CharGenerator\\result\\2.txt"))
            {
                for (int i = 0; i < 20; i++)
                {
                    slovo = g2.Word();
                    for (int j = 0; j < slovo.Length; j++)
                    {
                        w.Write(slovo[j]);
                        k++;
                    }
                }
            }
            using (StreamReader f = new StreamReader("D:\\CharGenerator\\result\\2.txt"))
            {
                text = f.ReadLine();
            }
            Assert.IsTrue(text.Length == k);
        }
        [TestMethod]
        public void Test6()
        {
            int k = 0;
            string paraslov;
            string text;
            TwoWordgen g3 = new TwoWordgen("D:\\CharGenerator\\result\\t.txt");
            using (StreamWriter w = new StreamWriter("D:\\CharGenerator\\result\\3.txt"))
            {
                for (int i = 0; i < 20; i++)
                {
                    paraslov = g3.TwoWords();
                    for (int j = 0; j < paraslov.Length; j++)
                    {
                        w.Write(paraslov[j]);
                        k++;
                    }
                }
            }
            using (StreamReader f = new StreamReader("D:\\CharGenerator\\result\\3.txt"))
            {
                text = f.ReadLine();
            }
            Assert.IsTrue(text.Length == k);
        }
    
    }
}

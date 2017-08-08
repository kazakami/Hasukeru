using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace kazakami
{

  class Program
  {

    static Dictionary<char, string> convert;

    static bool inQuote = false;

    private static void mapInit()
    {
      convert = new Dictionary<char, string>();
      convert.Add('主', "main");
      convert.Add('定', "=");
      convert.Add('穢', "IO");
      convert.Add('空', "()");
      convert.Add('固', "const");
      convert.Add('推', "::");
      convert.Add('行', "do");
      convert.Add('曰', "putStrLn");
      convert.Add('同', "id");
      convert.Add('写', "map");
      convert.Add('結', "concat");
      convert.Add('畳', "foldr");
      convert.Add('甲', "fst");
      convert.Add('乙', "snd");
      convert.Add('種', "class");
      convert.Add('属', "instance");
      convert.Add('字', "Char");
      convert.Add('文', "String");
      convert.Add('型', "Type");
      convert.Add('値', "data");
      convert.Add('有', "Maybe");
      convert.Add('虚', "Nothing");
      convert.Add('正', "Just");
      convert.Add('両', "Either");
      convert.Add('右', "Right");
      convert.Add('左', "Left");
      convert.Add('理', "Bool");
      convert.Add('真', "True");
      convert.Add('偽', "False");

      convert.Add('零', "0");
      convert.Add('一', "1");
      convert.Add('壱', "1");
      convert.Add('二', "2");
      convert.Add('三', "3");
      convert.Add('四', "4");
      convert.Add('五', "5");
      convert.Add('六', "6");
      convert.Add('七', "7");
      convert.Add('八', "8");
      convert.Add('九', "9");
      convert.Add('十', "10");
      convert.Add('百', "100");
      convert.Add('、', "$");
      convert.Add('加', "(+)");
      convert.Add('減', "(-)");
      convert.Add('乗', "(*)");
      convert.Add('除', "(/)");
      convert.Add('阿', "a");
      convert.Add('示', "show");
      convert.Add('至', "..");
      convert.Add('「', "(");
      convert.Add('」', ")");
      convert.Add('但', "|");
      //convert.Add('', "");

    }

    public static int Main(string[] argv)
    {
      mapInit();
      string line;
      using (StreamReader sr = new StreamReader(argv[0])) {
        while ((line = sr.ReadLine()) != null) {
          Console.WriteLine(toHaskell(line));
        }
      }
      return 0;
    }

    private static string toHaskell(string s)
    {
      string str = "";
      foreach (char c in s)
      {
        str += toHaskellCode(c);
      }
      return str;
    }

    private static string toHaskellCode(char c)
    {
      if (c == '『')
      {
        inQuote = true;        
        return "\"";
      }
      else if (c == '』')
      {
        inQuote = false;
	return "\"";
      }
      else if (inQuote)
      {
        return c.ToString();
      }
      else if (convert.ContainsKey(c))
      {
        return convert[c] + " ";
      }
      else if (c == ' ' || c == '　' || c == '\t')
      {
        return " ";
      }
      else if (c == '-' || c == '[' || c == ']')
      {
        return c.ToString();
      }
      else
      {
        return "var" + c.GetHashCode().ToString().Replace('-', 'm') + " ";
      }
    }
  }

}

using System;
using System.Collections.Generic;

namespace Level1Space
{
  public static class Level1
  {
      public static int [] WordSearch(int len, string s, string subs)
        {
            int a = 0; //счетчик пробелов
            int counterString = 0; //счетчик строк в массиве
            string[] gotov = new string[s.Length]; //массив строк , на которые разделим большую строку по заданной ширине
            for (int i = 0; i < s.Length;i++)
            {
                if (Char.IsWhiteSpace(s,i))
                {
                    a++;
                }
            }
            if (a != 0)
            {
                string[] words = s.Split(' '); //делим строку на слова по пробелам



                string summary = null; // временная строка до присвоения в массив строк
                string medium = null;
                for (int i = 0; i < words.Length - 1; i++)
                {
                    if (summary == null)
                        summary = words[i];

                    if (summary.Length < len)
                    {
                        summary = summary + " "; //перед прибавлением следующего слова прибавляем пробел
                        if (summary.Length < len)
                        {
                            medium = summary + words[i + 1];//прибавляем следующее слово и проверяем, умещается ли оно по заанной ширине

                            if (medium.Length > len)
                            {
                                gotov[counterString] = summary; //если не умещается, убираем прибавленное слово
                                summary = words[i + 1];
                                counterString++;
                            }
                            else
                            {
                                summary = medium;
                            }

                        }
                        else
                        {
                            gotov[counterString] = summary;
                            summary = null;
                            counterString++;
                        }

                    }
                    else if (summary.Length == len)
                    {
                        gotov[counterString] = summary;
                        summary = null;
                        counterString++;
                    }
                    else
                    {
                        gotov[counterString] = summary.Substring(0, 12);
                        summary = summary.Substring(12, summary.Length - 12);
                        i--;
                        counterString++;
                    }
                }
                // разбираемся с последним словом
                if (summary == null)
                    summary = words[words.Length - 1];
                while (summary != null)
                {
                    if (summary.Length <= len)
                    {
                        gotov[counterString] = summary;
                        summary = null;
                        counterString++;
                    }
                    else
                    {
                        gotov[counterString] = summary.Substring(0, 12);
                        summary = summary.Substring(12, summary.Length - 12);
                        counterString++;
                    }

                }
            }

            else
            {
                counterString = 1;
                gotov[0] = s;
            }
            int[] wordFounder = new int[counterString ];//массив чисел указывающих, обнаружено ли слово

            if (a != 0)
            {
                for (int i = 0; i < counterString; i++)
                {
                    bool b = gotov[i].Contains(subs);
                    if (b)
                    {
                        int index = gotov[i].IndexOf(subs);
                        if ((index == 0 && Char.IsWhiteSpace(gotov[i], subs.Length))
                            || (index == gotov[i].Length - subs.Length && Char.IsWhiteSpace(gotov[i], gotov[i].Length - subs.Length - 1))
                            || (Char.IsWhiteSpace(gotov[i], index - 1) && Char.IsWhiteSpace(gotov[i], index + subs.Length)))

                            wordFounder[i] = 1;
                        else wordFounder[i] = 0;

                    }
                }
            }
            else
            {
                if (gotov[0].Contains(subs) && gotov[0].Length == subs.Length)
                    wordFounder[0] = 1;
                else
                    wordFounder[0] = 0;
            }
            return wordFounder;
        }
  }
}

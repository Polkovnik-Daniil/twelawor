using Class1;
using System;
using System.IO;
using System.Reflection;

namespace ConsoleApp1
{
    static class Reflection
    {
        ///////////////////it`s for example///////////////////
        public static string str { get; set; }
        public static int integ { get; set; }
        public static int a;
        public static string a_;
        public static string Display_information_Full_Name(Type t)
        {
            string a = t.FullName;
            return a;
        }
        public static ConstructorInfo[] Display_Type()
        {
            object obj = Display_information_Full_Name(typeof(Reflection));
            Type type = obj.GetType();
            ConstructorInfo[] info = type.GetConstructors();
            return info;
        }
        public static MethodInfo[] Getmethod(Type t)
        {
            MethodInfo[] MArr = t.GetMethods(BindingFlags.Public | BindingFlags.Static);
            return MArr;
        }
        public static PropertyInfo[] Get_Properties(Type t)
        {
            PropertyInfo[] myPropertyInfo = t.GetProperties();
            return myPropertyInfo;
        }
        public static FieldInfo[] Get_Field(Type t)
        {
            FieldInfo[] fieldNames = t.GetFields();
            return fieldNames;
        }
        public static object[] Get_Interface(Type t)
        {
            object[] intef = t.GetInterfaces();
            return intef;
        }
        public static string WriteToFile(string fullname, ConstructorInfo[] info, MethodInfo[] arrMethodInfo, PropertyInfo[] myPropertyInfo, FieldInfo[] myFieldInfo, object[] inter)
        {
            string writePath = @"D:\Даник\Учеба\3 семестр\ООП\Лабораторные работы\12\ConsoleApp1\ConsoleApp1\file.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine("---------------------------------------");
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine("Full Name: \t\n\t\t" + fullname);
                    sw.WriteLine("---------------------------------------");
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine("Constructors: ");
                    for (int i = 0; i < info.Length; i++)
                        sw.WriteLine("\t\t" + info[i]);
                    sw.WriteLine("---------------------------------------");
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine("Methods: ");
                    for (int i = 0; i < arrMethodInfo.Length; i++)
                        sw.WriteLine("\t\t" + arrMethodInfo[i]);
                    sw.WriteLine("---------------------------------------");
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////            
                    sw.WriteLine("Properties: ");
                    foreach (var t in myPropertyInfo)
                        sw.WriteLine("\t\t" + t);
                    sw.WriteLine("---------------------------------------");
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine("Fields: ");
                    foreach (var t in myFieldInfo)
                        sw.WriteLine("\t\t" + t);
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine("---------------------------------------");
                    sw.WriteLine("Interfaces: ");
                    foreach (var t in inter)
                        sw.WriteLine("\t\t" + t);
                    sw.WriteLine("---------------------------------------");
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////
                    sw.WriteLine("Parameters Methods: ");
                    for (int i = 0; i < arrMethodInfo.Length; i++)
                    {
                        sw.WriteLine("\tMethods:\t" + arrMethodInfo[i]);
                        sw.Write("\t Parameters:\t ");
                        ParameterInfo[] methodInfoParamet = arrMethodInfo[i].GetParameters();
                        foreach (var it in methodInfoParamet)
                        {
                            sw.WriteLine("" + it);
                            sw.Write("\t\t\t ");
                        }
                        sw.WriteLine();
                    }
                    sw.WriteLine("---------------------------------------");
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return writePath;
        }
        public static bool ReadToFile(string path, string name_method, string Name_Class)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    bool bl = false;
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        line = line.Remove(0, 2);
                        if (name_method == line)
                        {
                            bl = true;
                        }
                        if (Name_Class == line && bl == false)
                        {
                            sr.Close();
                            return true;
                        }
                        else if (bl == true)
                        {
                            return false;
                        }
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;

        }
        public static void Call_method(string name_method, string Name_Class, string str)
        {
            try
            {
                Type type = Type.GetType(Name_Class);
                if (type != null)
                {
                    MethodInfo method = typeof(Airline).GetMethod(name_method);                                                                                                             //Void Show_that_it_ready(System.String)
                    if (method != null)
                    {
                        object result = null;
                        ParameterInfo[] parameters = method.GetParameters();
                        object p = Activator.CreateInstance(type, null);
                        if (parameters.Length == 0)
                        {
                            result = method.Invoke(p, null);
                            Console.WriteLine(result);
                        }
                        else
                        {
                            object[] parametersArray = new object[] { str };
                            result = method.Invoke(p, parametersArray);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static Type Create(string type)
        {
            Type tp = Type.GetType(type);
            return tp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Type t1 = typeof(Reflection).GetType();
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Полное Имя:             {0}", t1.FullName);
            Console.WriteLine("Базовый класс:          {0}", t1.BaseType);
            Console.WriteLine("Абстрактный:            {0}", t1.IsAbstract);
            Console.WriteLine("Это COM объект:         {0}", t1.IsCOMObject);
            Console.WriteLine("Запрещено наследование: {0}", t1.IsSealed);
            Console.WriteLine("Это class:              {0}", t1.IsClass);
            Console.WriteLine("---------------------------------------");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            string fullname = Reflection.Display_information_Full_Name(typeof(Reflection));
            Console.WriteLine("Full Name: \t\n\t\t" + fullname);
            Console.WriteLine("---------------------------------------");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            ConstructorInfo[] info = Reflection.Display_Type();
            Console.WriteLine("Constructors: ");
            for (int i = 0; i < info.Length; i++)
                Console.WriteLine("\t\t" + info[i]);
            Console.WriteLine("---------------------------------------");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            MethodInfo[] arrMethodInfo = Reflection.Getmethod(typeof(Airline));
            Console.WriteLine("Methods: ");
            for (int i = 0; i < arrMethodInfo.Length; i++)
                Console.WriteLine("\t\t" + arrMethodInfo[i]);
            Console.WriteLine("---------------------------------------");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////            
            PropertyInfo[] myPropertyInfo = Reflection.Get_Properties(typeof(Reflection));
            Console.WriteLine("Properties: ");
            foreach (var t in myPropertyInfo)
                Console.WriteLine("\t\t" + t);
            Console.WriteLine("---------------------------------------");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            FieldInfo[] myFieldInfo = Reflection.Get_Field(typeof(Reflection));
            Console.WriteLine("Fields: ");
            foreach (var t in myFieldInfo)
                Console.WriteLine("\t\t" + t);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("---------------------------------------");
            object[] inter = Reflection.Get_Interface(typeof(Reflection));
            Console.WriteLine("Interfaces: ");
            foreach (var t in inter)
                Console.WriteLine("\t\t" + t);
            Console.WriteLine("---------------------------------------");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Parameters Methods: ");
            for (int i = 0; i < arrMethodInfo.Length; i++)
            {
                Console.WriteLine("\tMethods:\t" + arrMethodInfo[i]);
                Console.Write("\t Parameters:\t ");
                ParameterInfo[] methodInfoParamet = arrMethodInfo[i].GetParameters();
                foreach (var it in methodInfoParamet)
                {
                    Console.WriteLine("" + it);
                    Console.Write("\t\t\t ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------------");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            string Path = Reflection.WriteToFile(fullname, info, arrMethodInfo, myPropertyInfo, myFieldInfo, inter);
            string Name_Class;
            Name_Class = "ConsoleApp1.Reflection";
            Console.WriteLine("Enter name of method: ");
            string name_method = Console.ReadLine();
            name_method = "Void Show_that_it_ready(System.String)";
            bool bl = Reflection.ReadToFile(Path, name_method, Name_Class);
            if (bl == true)
            {
                Name_Class = "Class1.Airline";
                Console.WriteLine("Method was found!");
                Console.Write("Enter string for confirmation! ");
                string str = Console.ReadLine();
                name_method = "Show_that_it_ready";
                Reflection.Call_method(name_method, Name_Class, str);
            }
            else
            {
                Console.WriteLine("Method wasn`t found! Because was enter uncorrected value");
            }
            string str_ = "ConsoleApp1.Reflection"; 
            Type tp = Reflection.Create(str_);
            Console.WriteLine("was create object with type: \t" + tp);
            Console.WriteLine("Bye World");
            Console.ReadKey();
        }
    }
}
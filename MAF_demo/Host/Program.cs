/*
    作者：GhostBear
    博客：http://blog.csdn.net/ghostbear
    简介：测试MAF，这段代码是宿主程序。该程序可以针对保存在某个目录下的插件来进行选择性调用。

 */



using System;
using System.Collections.ObjectModel;
using System.AddIn.Hosting;
using System.Collections.Generic;
using System.IO;

namespace Host
{
    /// <summary>
    /// https://msdn.microsoft.com/en-gb/library/bb384240(v=vs.100).aspx
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Init pipline, create PipelineSegments.store and AddIns.store
            string path = Environment.CurrentDirectory;
            AddInStore.Update(path);

            //string[] warnings = AddInStore.Update(path);
            //foreach (var tmp in warnings)
            //{
            //    Console.WriteLine(tmp);
            //}

            //发现, used the host side view(without attribute)
            var tokens = AddInStore.FindAddIns(typeof(HostSideView.HostSideView), path);
            Console.WriteLine("当前共有{0}个插件可以选择。它们分别为：", tokens.Count);

            var index = 1;
            foreach (var tmp in tokens)
            {
                Console.WriteLine(string.Format("[{4}]名称：{0}，描述：{1}，版本：{2}，发布者：{3}", tmp.Name, tmp.Description, tmp.Version, tmp.Publisher, index++));
            }

            //[[ find addin in the another folder
            string anotherAddInPath = @"C:\OutPutForAddIn\Test";
            AddInStore.RebuildAddIns(anotherAddInPath);

            //todo: why there find the addin in the fist folder????
            IList<AddInToken> PluginList = AddInStore.FindAddIns(typeof(HostSideView.HostSideView), PipelineStoreLocation.ApplicationBase, anotherAddInPath);
            //]]

            var token = ChooseCalculator(tokens);

            //隔离和激活插件
            AddInProcess process = new AddInProcess();//(Platform.X64);
            process.Start();

            var addin = token.Activate<HostSideView.HostSideView>(process, AddInSecurityLevel.FullTrust);

            Console.WriteLine("PID:{0}", process.ProcessId);

            //调用插件
            Console.WriteLine(addin.Say());

            Console.ReadKey();
        }

        private static AddInToken ChooseCalculator(Collection<AddInToken> tokens)
        {
            if (tokens.Count == 0)
            {
                Console.WriteLine("No calculators are available");

                return null;
            }

            Console.WriteLine("Available Calculators: ");

            // Show the token properties for each token in the AddInToken collection 
            // (tokens), preceded by the add-in number in [] brackets.

            int tokNumber = 1;

            foreach (AddInToken tok in tokens)
            {
                Console.WriteLine(String.Format("\t[{0}]: {1} - {2}\n\t{3}\n\t\t {4}\n\t\t {5} - {6}",
                    tokNumber.ToString(),
                    tok.Name,
                    tok.AddInFullName,
                    tok.AssemblyName,
                    tok.Description,
                    tok.Version,
                    tok.Publisher));

                tokNumber++;
            }

            Console.WriteLine("Which calculator do you want to use?");

            String line = Console.ReadLine();

            int selection;

            if (Int32.TryParse(line, out selection))
            {
                if (selection <= tokens.Count)
                {
                    return tokens[selection - 1];
                }
            }

            Console.WriteLine("Invalid selection: {0}. Please choose again.", line);

            return ChooseCalculator(tokens);
        }
    }
}
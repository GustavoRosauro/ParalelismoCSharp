using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace ExemploParalelismo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var listaTasks = new List<Task>(3);
                for (int i = 0; i < 3; i++)
                {
                    Task task = new Task(() =>
                    {
                        ChamarTasksDinamicas(Task.CurrentId);
                    });
                    task.Start();
                    listaTasks.Add(task);
                }
                Console.Write("Iniciado");
                Task.WaitAll(listaTasks.ToArray());                
            }
            catch (AggregateException ex)
            {

                foreach (var msg in ex.InnerExceptions)
                    Console.WriteLine(msg.Message);                
            }
            Console.Write("fim da execução");
            Console.ReadLine();
        }
        public static void ChamarTasksDinamicas(int? id)
        {
            Type type = Type.GetType("ExemploParalelismo.TaskRule");
            Object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod("ExecutarRotina");
            methodInfo.Invoke(obj,new object[]{id});
        }
    }
}

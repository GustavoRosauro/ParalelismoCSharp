using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploParalelismo
{
    public class TaskRule
    {
        public void ExecutarRotina(int? id)
        {
            Console.WriteLine($"chamando Task {id}");
        }
    }
}

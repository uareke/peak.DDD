using System.Collections.Generic;
using System.Linq;

namespace peak.DDD.Domain.Helpers
{
    public class SplitEntrada
    {
        public List<string> SplitDados(string valores)
        {
            string[] SwitchStrings = { ",", "-" };
            List<string> retorno = new List<string>();

            switch (SwitchStrings.FirstOrDefault<string>(s => valores.Contains(s)))
            {
                case ",":
                    if (valores.Contains("-"))
                    {
                        throw new System.ArgumentException("Erro ao tentar executar a tarefa");
                    }
                    var splitt = valores.Split(",")
                                .Where(x => x != string.Empty)
                                .Distinct()
                                .ToList();
                    var arr = splitt.OrderBy(x => x.PadLeft(4, '0')).ToArray();
                    foreach(var word in arr)
                    {
                        retorno.Add(word.PadLeft(4, '0'));
                    }
                    break;
                case "-":
                    if (valores.Contains(","))
                    {
                        throw new System.ArgumentException("Erro ao tentar executar tarefa");
                    }
                    var pslitv = valores.Split('-')[0];
                    var lspliv = valores.Split('-').Last();
                    if (int.Parse(pslitv) > int.Parse(lspliv))
                    {
                        throw new System.ArgumentException("Não foi possivel executar a trarefa");
                    } else if (pslitv == lspliv)
                    {
                        throw new System.ArgumentException("Para pesquisa de um unico cliente informe um codigo");
                    } else
                    {
                        for (int i = int.Parse(pslitv); i < int.Parse(lspliv)+1; i++)
                        {
                            retorno.Add(i.ToString());
                        }
                    }
                    break;
                default:
                    throw new System.ArgumentException("Não foi possivel efetuar a pesquisa");
                   
            }
            return retorno;
        }


        }
}

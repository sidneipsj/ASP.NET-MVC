using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using JsonFx;
//using JsonFx.Json;

namespace JsonSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //ConvertObjetoToJson();
            //ConvertJsonToObject();
            ConvertJsonToDynamicObject3();
        }

        //Convertendo um objeto definido para JSON
        static void ConvertObjetoToJson()
        {
            Endereco e1 = new Endereco
            {
                Cod = 1,
                Logradouro = "Rua teste",

            };
            Pessoa p = new Pessoa
            {

                Cod = 1,
                Nome = "Sidnei Peres Sanches Junior",
                Idade = 27,
                Endereco = e1
            };

            string json = JsonConvert.SerializeObject(p);

            Console.WriteLine(json);
            Console.ReadKey();
        }

        //Convertendo um Json para um objeto específico
        static void ConvertJsonToObject()
        {
            string json = "{ 'Cod': 1,'Nome':'Sidnei Peres'  }";
            Pessoa p2 = JsonConvert.DeserializeObject<Pessoa>(json);
            Console.WriteLine(Convert.ToString(p2.Cod) + ", " + p2.Nome);
            Console.ReadKey();
        }

        //Convertendo um Json para um objeto dinamico exemplo contém lista dinâmica
        static void ConvertJsonToDynamicObject3()
        {
            Pessoa p1 = new Pessoa
            {

                Cod = 1,
                Nome = "Sidnei Peres Sanches Junior",
                Idade = 27,
                //Endereco = e1
            };
            Pessoa p2 = new Pessoa
            {

                Cod = 2,
                Nome = "Marcelly Monteiro",
                Idade = 26,
                //Endereco = e1
            };

            //Convertendo uma lista de objetos dinâmicos para JSON
            List<dynamic> lista = new List<dynamic>();
            lista.Add(p1);
            lista.Add(p2);
            string json = "{ 'Cod': 1,'Nome':'Sidnei Peres'  }";
            dynamic result = JsonConvert.SerializeObject(lista);
            Console.WriteLine(result);


            //Descerializando um JSON para uma lista de objtos dinâmicos. Referência abaixo
            //http://stackoverflow.com/questions/4749639/deserializing-json-to-net-object-using-newtonsoft-or-linq-to-json-maybe
            dynamic PessoaList = JsonConvert.DeserializeObject(result);
            //var pessoa = PessoaList.pessoa;

            foreach (var item in PessoaList)
            {
                string cod = item["Cod"];
            }


            Console.ReadKey();
        }


        static void ConvertJsonToDynamicObject()
        {
            string json = "{ 'Cod': 1,'Nome':'Sidnei Peres'  }";
            dynamic stuff = JObject.Parse(json);
            int cod = stuff.Cod;
            Console.WriteLine(Convert.ToString(cod));
            Console.ReadKey();
        }

        //Convertendo JsonToDynamicObject usando o plugin JsonFX - Para funcionar tive que comentar a referência 
        //do Newtonsoft.Json
        //https://github.com/jsonfx/jsonfx
        static void ConvertJsonToDynamicObject2()
        {
            //var reader = new JsonReader(); var writer = new JsonWriter();

            //string input = @"{ ""foo"": true, ""array"": [ 42, false, ""Hello!"", null ] }";
            //dynamic output = reader.Read(input);

            //Console.WriteLine(output.array[0]); // 42

            //string json = writer.Write(output);

            //Console.WriteLine(json); // {"foo":true,"array":[42,false,"Hello!",null]}

            //Console.ReadKey();

            
        }
    }
}

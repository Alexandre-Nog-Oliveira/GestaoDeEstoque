using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjetoGestaoEstoque
{
    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();

        enum Menu { Listar = 1, Adicionar, Remover, Entrada, Saida, Sair }
        static void Main()
        {
            ToCharge();
            bool ExitFromMenu = false;
            while (ExitFromMenu == false)
            {
                Console.WriteLine("Seu estoque");
                Console.WriteLine("1-Listar\n2-Adicionar\n3-Remover\n4-Registrar entrada\n5-Registrar Saída\n6-Sair ");
                string Option = Console.ReadLine();
                int OptionInt = int.Parse(Option);

                if (OptionInt > 0 && OptionInt <= 6)
                {
                    Menu Choice = (Menu)OptionInt;
                    switch (Choice)
                    {
                        case Menu.Listar:
                            ProductListing();
                            break;
                        case Menu.Adicionar:
                            Register();
                            break;
                        case Menu.Remover:
                            ToRemove();
                            break;
                        case Menu.Entrada:
                            Prohibited();
                            break;
                        case Menu.Saida:
                            Exit();
                            break;
                        case Menu.Sair:
                            ExitFromMenu = true;
                            Console.Write("Fechando o menu...");
                            break;
                    }
                }
                else
                {
                    Console.Write("Opção {0} não encontrada, por favor escolha uma das opções acima", OptionInt);
                    ExitFromMenu = true;
                }
                Console.Clear();
            }         
        }
        static void ProductListing()
        {
            Console.WriteLine("lista de produtos");
            int identity = 0;
            foreach (IEstoque produto in produtos)
            {
                Console.WriteLine("ID: {0}", identity);
                produto.Display();
                identity++;
            }
            Console.ReadLine();
        }
        static void ToRemove()
        {
            ProductListing();
            Console.WriteLine("Digite o ID do elemento que você quer remover: ");
            int idProduct = int.Parse(Console.ReadLine());
            if(idProduct >= 0 && idProduct < produtos.Count)
            {
                produtos.RemoveAt(idProduct);
                Save();
            }
        }
        static void Prohibited()
        {
            ProductListing();
            Console.WriteLine("Digite o ID do elemento que você quer dar entrada: ");
            int idProduct = int.Parse(Console.ReadLine());
            if (idProduct >= 0 && idProduct < produtos.Count)
            {
                produtos[idProduct].AddInput();
                Save();
            }
        }
        static void Exit()
        {
            ProductListing();
            Console.WriteLine("Digite o ID do elemento que você quer dar baixa: ");
            int idProduct = int.Parse(Console.ReadLine());
            if (idProduct >= 0 && idProduct < produtos.Count)
            {
                produtos[idProduct].AddOutput();
                Save();
            }
        }

        enum OptionToRegister { PhysicalProductRegister= 1, Ebook, Course }

        static void Register()
        {
            Console.WriteLine("Cadastro de produtos");
            Console.WriteLine("1-Produto fisico\n2-Ebook\n3-Curso");
            String OptionChosenForRegistration = Console.ReadLine();
            int OptionChosenForRegistrationInt = int.Parse(OptionChosenForRegistration);

            OptionToRegister ChoiceOfRegistration= (OptionToRegister)OptionChosenForRegistrationInt;
            switch (ChoiceOfRegistration)
            {
                case OptionToRegister.PhysicalProductRegister:
                    RegisterPhysicalProduct();
                    break;

                case OptionToRegister.Ebook:
                    RegisterEbook();
                    break;

                case OptionToRegister.Course:
                    RegisterCourse();
                    break;
            }
        }
        static void RegisterPhysicalProduct()
        {
            Console.WriteLine("Cadastrando Produto fisico: ");
            Console.WriteLine("Nome: ");
            string name = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Frente: ");
            float freight = float.Parse(Console.ReadLine());
            Console.WriteLine("Codigo de barras");
            ulong barcode = ulong.Parse(Console.ReadLine());
  
            PhysicalProduct Product =  new PhysicalProduct(name, price, freight, barcode);
            produtos.Add(Product);
            Save();
        }
        static void RegisterEbook()
        {
            Console.WriteLine("Cadastrando Ebook: ");
            Console.WriteLine("Nome: ");
            string name = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string author = Console.ReadLine();

            Ebook Product = new Ebook(name, price,author);
            produtos.Add(Product);
            Save();
        }
        static void RegisterCourse()
        {
            Console.WriteLine("Cadastrando Curso: ");
            Console.WriteLine("Nome: ");
            string name = Console.ReadLine();
            Console.WriteLine("Preço: ");
            float price = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: ");
            string author = Console.ReadLine();

            Course Product = new Course(name, price, author);
            produtos.Add(Product);
            Save();
        }
        static void Save()
        {
            FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder =  new BinaryFormatter();
            enconder.Serialize(stream, produtos);
            stream.Close();
        }
        static void ToCharge()
        {
            FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter enconder = new BinaryFormatter();
            try
            {
                produtos = (List<IEstoque>)enconder.Deserialize(stream);                
                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception error)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();
        }
    }
}

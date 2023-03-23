using ProjEstanteLivros;
using System.Reflection;
using System.Security.AccessControl;

internal class Program
{
    private static void Main(string[] args)
    {
        bool changeMore = true;
        string t, a, isbn;
        string reading;
        int menu = 0;

        List<Book> shelf = new List<Book>();
        List<Book> lend = new List<Book>();
        List<Book> toRead = new List<Book>();
        List<Book> isReading = new List<Book>();
        List<Book> alreadyRead = new List<Book>();

        do
        {
            Menu();
            Console.Write("Escolha uma função de 1 a 12:  ");
            menu = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (menu)
            {
                case 1:
                    AddBooks();
                    //escrever o arquivo;
                    Console.Clear();
                    break;

                case 2:
                    RemoveBooks();

                    Console.Clear();
                    break;
                case 3:
                    EditBooks(); 
                    Console.Clear();
                    break;
                case 4:
                    LendBooks();
                    Console.Clear();
                    break;
                case 5:
                    GetBackBook();
                    Console.Clear();
                    break;

                case 6:
                    ReadingBooks();
                    Console.Clear();
                    break;
                case 7:
                    foreach (var book in shelf)
                    {
                        Console.WriteLine(book.ToString());
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 8:
                    foreach (var book in shelf)
                    {
                        Console.WriteLine(book.ToString());
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 9:
                    foreach (var book in isReading)
                    {
                        Console.WriteLine(book.ToString());
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 10:
                    foreach (var book in lend)
                    {
                        Console.WriteLine(book.ToString());
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 11:
                    foreach (var book in alreadyRead)
                    {
                        Console.WriteLine(book.ToString());
                    }
                    Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case 12:
                    Console.WriteLine(" Até mais :)");
                    Thread.Sleep(2000);
                    break;

            }
        } while (menu != 12);





        //MÉTODOS////////////////////////////

        void AddBooks()
        {
            while (changeMore != false)
            {
                Console.Write("Título:");
                t = Console.ReadLine();

                Console.Write("Autor:");
                a = Console.ReadLine();

                Console.Write("ISBN:");
                isbn = Console.ReadLine();

                do
                {
                    Console.WriteLine("\nEste livro está: \n(0)-Sendo lido \n(1)-A ler \n(2)-Já lido");
                    reading = Console.ReadLine();
                } while (reading != "0" && reading != "1" && reading != "2");

                Book book = new(t, a, isbn, reading);
                shelf.Add(book);
                foreach (var b in shelf)
                {
                    Console.WriteLine(book.ToString());
                }
                //////////////////////////
                if (reading == "0")
                    isReading.Add(book);
                if (reading == "1")
                    toRead.Add(book);
                if (reading == "2")
                    alreadyRead.Add(book);
                //////////////////////////
                Console.WriteLine("\nDeseja cadastrar mais livros? Sim (S)  | Não(N)");
                char r = char.Parse(Console.ReadLine().ToUpper());
                if (r == 'N')
                    changeMore = false;
            }

        }

        void RemoveBooks()
        {
            changeMore = true;
            while (changeMore != false)
            {
                foreach (var book in shelf)
                {
                    Console.WriteLine(book.ToString());
                }

                Console.WriteLine("ISBN do livro a ser removido:");
                isbn = Console.ReadLine();
                var livroAchado = shelf.FirstOrDefault(x => x.ISBN == isbn);
                // achei no https://pt.stackoverflow.com/questions/87315/atualizar-um-elemento-de-uma-lista-gen%c3%a9rica-por-um-item-espec%c3%adfico
                if (livroAchado != null)
                {
                    shelf.Remove(livroAchado);
                }
                else
                    Console.WriteLine("ISBN inválido, tente novamente.");

                Console.WriteLine("Deseja remover mais livros? Sim (S)  | Não(N)");
                char r = char.Parse(Console.ReadLine().ToUpper());
                if (r == 'N')
                    changeMore = false;
            }
        }

        void LendBooks()
        {
            changeMore = true;
            while (changeMore != false)
            {
                foreach (var book in shelf)
                {
                    Console.WriteLine(book.ToString());
                }

                Console.WriteLine("ISBN do livro a ser emprestado:");
                isbn = Console.ReadLine();
                var livroAchado = shelf.FirstOrDefault(x => x.ISBN == isbn);
                // achei no https://pt.stackoverflow.com/questions/87315/atualizar-um-elemento-de-uma-lista-gen%c3%a9rica-por-um-item-espec%c3%adfico
                if (livroAchado != null)
                {
                    lend.Add(livroAchado);
                    shelf.Remove(livroAchado);
                }
                else
                    Console.WriteLine("ISBN inválido, tente novamente.");


                Console.WriteLine("Deseja emprestar mais livros? Sim (S)  | Não(N)");
                char r = char.Parse(Console.ReadLine().ToUpper());
                if (r == 'N')
                    changeMore = false;
            }
        }

        void GetBackBook()
        {
            changeMore = true;
            while (changeMore != false)
            {
                foreach (var book in lend)
                {
                    Console.WriteLine(book.ToString());
                }

                Console.WriteLine("ISBN do livro a ser pego de volta:");
                isbn = Console.ReadLine();
                var livroAchado = lend.FirstOrDefault(x => x.ISBN == isbn);
                if (livroAchado != null)
                {
                    shelf.Add(livroAchado);
                    lend.Remove(livroAchado);
                }
                else
                    Console.WriteLine("ISBN inválido, tente novamente.");


                Console.WriteLine("Deseja pegar de volta mais livros? Sim (S)  | Não(N)");
                char r = char.Parse(Console.ReadLine().ToUpper());
                if (r == 'N')
                    changeMore = false;
            }
        }

        void EditBooks()
        {
            changeMore = true;
            while (changeMore != false)
            {
                foreach (var book in shelf)
                {
                    Console.WriteLine(book.ToString());
                }

                Console.WriteLine("ISBN do livro a ser editado:");
                isbn = Console.ReadLine();
                var livroAchado = shelf.FirstOrDefault(x => x.ISBN == isbn);
                Console.WriteLine(livroAchado.ToString());  


                if (livroAchado != null)
                {
                    var answer = 0;
                    Console.WriteLine("(1)-Título\n(2)-Autor\n(3)-ISBN\nQual propriedade você deseja alterar?");
                    int.TryParse(Console.ReadLine(), out answer);
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine(livroAchado.ToString());
                            Console.WriteLine("Qual o novo título?");
                            livroAchado.EditTitle();
                            Console.WriteLine(livroAchado.ToString());
                            break;

                        case 2:
                            Console.WriteLine(livroAchado.ToString());
                            Console.WriteLine("Qual o novo autor?");
                            livroAchado.EditAuthor();
                            Console.WriteLine(livroAchado.ToString());
                            Console.ReadKey();
                            break;

                        case 3:
                            Console.WriteLine(livroAchado.ToString());
                            Console.WriteLine("Qual o novo ISBN?");
                            livroAchado.EditISBN();
                            Console.WriteLine(livroAchado.ToString());
                            break;

                        default:
                            Console.WriteLine("Escolha 1, 2 ou 3.");
                            break;
                    }
                }

                else
                    Console.WriteLine("Id inválido tente outro");


                Console.WriteLine("Deseja editar mais livros? Sim (S)  | Não(N)");
                char r = char.Parse(Console.ReadLine().ToUpper());
                if (r == 'N')
                    changeMore = false;
            }
        }

        void ReadingBooks()
        {
            changeMore = true;
            while (changeMore != false)
            {
                foreach (var book in shelf)
                {
                    Console.WriteLine(book.ToString());
                }

                Console.WriteLine("ISBN do livro a ser mudado o estado de leitura:");
                isbn = Console.ReadLine();
                var livroAchado = shelf.FirstOrDefault(x => x.ISBN == isbn);
                Console.WriteLine(livroAchado.ToString());


                if (livroAchado != null)  // 0-sendo lindo   1- a ler   2-já lido
                {
                    if (livroAchado.Reading=="0")
                    {
                        livroAchado.EditReading();
                        if (livroAchado.EditReading() == "1")
                        {
                            toRead.Add(livroAchado);
                            isReading.Remove(livroAchado);
                        }
                        if(livroAchado.EditReading() == "2")
                        {
                            alreadyRead.Add(livroAchado);
                            isReading.Remove(livroAchado);
                        }
                    }

                    if (livroAchado.Reading == "1")
                    {
                        livroAchado.EditReading();
                        if (livroAchado.EditReading() == "0")
                        {
                            isReading.Add(livroAchado);
                            toRead.Remove(livroAchado);
                        }
                        if (livroAchado.EditReading() == "2")
                        {
                            alreadyRead.Add(livroAchado);
                            toRead.Remove(livroAchado);
                        }
                    }

                    if (livroAchado.Reading == "2")
                    {
                        livroAchado.EditReading();
                        if (livroAchado.EditReading() == "0")
                        {
                            isReading.Add(livroAchado);
                            alreadyRead.Remove(livroAchado);
                        }
                        if (livroAchado.EditReading() == "1")
                        {
                            toRead.Add(livroAchado);
                            alreadyRead.Remove(livroAchado);
                        }
                    }
                }
                else
                    Console.WriteLine("Id inválido tente outro");


                Console.WriteLine("Deseja editar o estado de leitura de mais livros? Sim (S)  | Não(N)");
                char r = char.Parse(Console.ReadLine().ToUpper());
                if (r == 'N')
                    changeMore = false;
            }
        }

        void Menu()
        {
            Console.WriteLine("Seja bem-vindo(a) a sua biblioteca particular S2");
            Console.WriteLine("\n\tFUNÇÕES");
            Console.WriteLine("(1)- Adicionar um livro;");
            Console.WriteLine("(2)- Remover um livro;");
            Console.WriteLine("(3)- Editar um livro;");
            Console.WriteLine("(4)- Emprestar um livro;");
            Console.WriteLine("(5)- Pegar de volta um livro que foi emprestado;");
            Console.WriteLine("(6)- Mudar o estado de leitura de um livro;");
            Console.WriteLine("(7)- Lista de livros totais;");
            Console.WriteLine("(8)- Lista de livros sendo lidos;");
            Console.WriteLine("(9)- Lista de livros a serem lidos;");
            Console.WriteLine("(10)- Lista de livros emprestados;");
            Console.WriteLine("(11)- Lista de livros já lidos;");
            Console.WriteLine("(12)- Sair da execução do programa;");

        }
    }
}


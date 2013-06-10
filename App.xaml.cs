using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace wp7ShareWords
{
    public partial class App : Application
    {
        private static MainViewModel viewModel = null;

        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The MainViewModel object.</returns>
        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
                if (viewModel == null)
                    viewModel = new MainViewModel();

                return viewModel;
            }
        }

        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        /// <summary>
        /// Constructor for the Application object.
        /// </summary>


        private const string conn = @"isostore:/Frases.sdf";

        public App()
        {
            using (var ctx = new wp7ShareWordsDataContext(conn))
            {


                if (ctx.DatabaseExists())
                {
                    ctx.DeleteDatabase();
                    ctx.CreateDatabase();

                    IList<Categoria> cat = new List<Categoria>();
                    IList<Frase> frases = new List<Frase>();

                    cat.Add(new Categoria { Nome = "Selecione" });
                    cat.Add(new Categoria { Nome = "Alegria" });
                    cat.Add(new Categoria { Nome = "Amizade" });
                    cat.Add(new Categoria { Nome = "Amor" });
                    cat.Add(new Categoria { Nome = "Arte" });
                    cat.Add(new Categoria { Nome = "Divertidas" });
                    cat.Add(new Categoria { Nome = "Educação" });
                    cat.Add(new Categoria { Nome = "Humanidade" });
                    cat.Add(new Categoria { Nome = "Motivacional" });
                    cat.Add(new Categoria { Nome = "Paz" });
                    cat.Add(new Categoria { Nome = "Pensamento" });
                    cat.Add(new Categoria { Nome = "Reflexão" });

                    //aqui
                    frases.Add(new Frase
                    {
                        Autor = "Georges Bernanos",
                        Titulo = "Segredo da felicidade",
                        Frases = "Saber encontrar a alegria na alegria dos outros, é o segredo da felicidade.",
                        Categoria_Id = 1
                    });

                    frases.Add(new Frase
                    {
                        Autor = "William Shakespeare",
                        Titulo = "Alegria e vida",
                        Frases = @"A alegria evita mil males e prolonga a vida.",
                        Categoria_Id = 1
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Joseph Addison",
                        Titulo = "Alegria,amizade e felicidade",
                        Frases = @"A amizade desenvolve a felicidade e reduz o sofrimento, duplicando a nossa alegria e dividindo a nossa dor.",
                        Categoria_Id = 1
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Khalil Gibran",
                        Titulo = "Tristeza e alegria",
                        Frases = "Aquele que nunca viu a tristeza, nunca reconhecerá a alegria.",
                        Categoria_Id = 1
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Mahatma Gandhi",
                        Titulo = "Alegria,luta e sofrimento",
                        Frases = @"A alegria está na luta, na tentativa, no sofrimento envolvido e não na vitoria propriamente dita.",
                        Categoria_Id = 1
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Léon Tolstoi",
                        Titulo = "Alegria de fazer o bem",
                        Frases = @"A alegria de fazer o bem é a única felicidade verdadeira.",
                        Categoria_Id = 1
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Johann Goethe",
                        Titulo = "Alegria não está nas coisas",
                        Frases = "A alegria não está nas coisas, está em nós.",
                        Categoria_Id = 1
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Alessandro Manzoni",
                        Titulo = "Deus nunca perturba",
                        Frases = @"(Deus)... nunca perturba a alegria dos seus filhos se não for para lhes preparar uma mais certa e maior.",
                        Categoria_Id = 1
                    });

                    frases.Add(new Frase
                    {
                        Autor = "M. Taniguchi",
                        Titulo = "Alegria aos outros",
                        Frases = @"Não há satisfação maior do que aquela que sentimos quando proporcionamos alegria aos outros.",
                        Categoria_Id = 1
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Honoré de Balzac",
                        Titulo = "Alegria só pode brotar",
                        Frases = "A alegria só pode brotar de entre as pessoas que se sentem iguais.",
                        Categoria_Id = 1
                    });

                    //1

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 2
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 2
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 2
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 2
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 2
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 2
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 2
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 2
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 2
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 2
                    });

                    //2

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 3
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 3
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 3
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 3
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 3
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 3
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 3
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 3
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 3
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 3
                    });

                    //3

                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 4
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 4
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 4
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 4
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 4
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 4
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 4
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 4
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 4
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 4
                    });

                    //4

                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Polenguinho",
                        Frases = "Polenguinho: o seu queijo quadradinho desde mil novecentos e bolinha",
                        Categoria_Id = 5
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 5
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 5
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 5
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 5
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 5
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 5
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 5
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 5
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 5
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 5
                    });

                    //5

                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 6
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 6
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 6
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 6
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 6
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 6
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 6
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 6
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 6
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 6
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 6
                    });
                    //60
                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 7
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 7
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 7
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 7
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 7
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 7
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 7
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 7
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 7
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 7
                    });

                    //70

                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 8
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 8
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 8
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 8
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 8
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 8
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 8
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 8
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 8
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 8
                    });

                    //80

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 9
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 9
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 9
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 9
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 9
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 9
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 9
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 9
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 9
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 9
                    });
                    //90

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 10
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 10
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 10
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 10
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 10
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 10
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 10
                    });

                    //100

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 11
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 11
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 11
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 11
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 11
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 11
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Elenice Adriano",
                        Titulo = "Amor Materno",
                        Frases = @"Amor é fogo que arde sem se ver; É ferida que dói e não se sente; É um contentamento descontente; É dor que desatina sem doer",
                        Categoria_Id = 11
                    });
                    frases.Add(new Frase
                    {
                        Autor = "Desconhecido",
                        Titulo = "Amor e sexo",
                        Frases = "Amo como ama o amor. Não conheço nenhuma outra razão para amar senão amar. Que queres que te diga, além de que te amo, se o que quero dizer-te é que te amo?",
                        Categoria_Id = 11
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Thiago Adriano",
                        Titulo = "sexo",
                        Frases = @"Amor não é se envolver com a pessoa perfeita, aquela dos nossos sonhos. Não existem príncipes nem princesas. Encare a outra pessoa de forma sincera e rea",
                        Categoria_Id = 11
                    });

                    frases.Add(new Frase
                    {
                        Autor = "Steve Jobs",
                        Titulo = "Sonho e futuro",
                        Frases = @"Cada sonho que você deixa pra trás, é um pedaço do seu futuro que deixa de existir.",
                        Categoria_Id = 11
                    });

                    //aqui termina



                    var countFrases = frases.Count();

                    foreach (var item in cat)
                    {
                        ctx.Categorias.InsertOnSubmit(item);
                    }

                    for (int i = 0; i < frases.Count(); i++)
                    {
                        ctx.Frases.InsertOnSubmit(frases[i]);
                    }

                    ctx.SubmitChanges();


                }
            }

            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;

            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = false;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }

        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
            // Ensure that application state is restored appropriately
            if (!App.ViewModel.IsDataLoaded)
            {
                // App.ViewModel.LoadData();
            }
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            // Ensure that required application state is persisted here.
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}
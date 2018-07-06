using System;

namespace Gra2WPF
{
    public partial class MainWindow
    {
        /// <summary>
        /// A class drawing a random factory from AvailableFactoryList
        /// </summary>
        public class ObjectRandomizer
        {
            public ObjectRandomizer(MainWindow window)
            {
                _Window = window;
            }

            public MainWindow _Window { get; }

            /// <summary>
            /// Chooses random factory by index.
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public void BuildNewObject(object sender, EventArgs e) //na podstawie właściwości frequency losuje fabrykę z listy, 
                                                                  //która wyprodukuje obiekt. 
                                                                 //wybiera tylko spośród trzech pierwszych zarejestrowanych fabryk                                                               
            {
                Random random = new Random();

                switch (random.Next(0, _Window.frequency)) //Range is set by the frequency property. Every drawn number higher than
                                                            //2 results with no produced factory.
                {
                    case 0:
                        try
                        {
                           AvailableFactoryList.Instance.list[0].GetObject(_Window).Appear(); //jeśli ta istnieje, to wywołuje 
                                                                                                //pierwszą fabrykę z listy.
                        }
                        catch { }
                        break;
                    case 1:
                        try
                        {
                            AvailableFactoryList.Instance.list[1].GetObject(_Window).Appear();//jeśli ta istnieje, 
                                                                                                //to wywołuje drugą fabrykę z listy.
                        }
                        catch { }
                        break;
                    case 2:
                        try
                        {
                            AvailableFactoryList.Instance.list[2].GetObject(_Window).Appear();//jeśli ta istnieje, to wywołuje 
                                                                                                //trzecią fabrykę z listy.
                        }
                        catch { }
                        break;
                }
            }        
        }
    }
}


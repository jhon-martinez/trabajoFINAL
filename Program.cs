using System;
using System.Collections.Generic;
using System.Linq;
using TRABAJO_final.Modelo;

namespace TRABAJO_final
{
    class 
        Program
    {
        static Validaciones Validar = new Validaciones();
        static void Main(string[] args)
        
        {
            string temporal;
            bool EntradaValida = false;
            int opc = 0;


            do
            {
                Marco();
                Console.Clear();
                Console.SetCursorPosition(25,9); Console.WriteLine("-- Menu Principal ---");
                Console.SetCursorPosition(25,11); Console.WriteLine("1. Crear un Estudiante");
                Console.SetCursorPosition(25,13); Console.WriteLine("2. Listar Estudiantes");
                Console.SetCursorPosition(25,15); Console.WriteLine("3. Buscar un Estudiante");
                Console.SetCursorPosition(25,17); Console.WriteLine("4. Editar un Estudiante");
                Console.SetCursorPosition(25,19); Console.WriteLine("5. Borrar un Estudiante ");
                Console.SetCursorPosition(25,21); Console.WriteLine("-------------------");
                Console.SetCursorPosition(25,23); Console.WriteLine("0. SALIR DEL SISTEMA");

                Console.SetCursorPosition(25,26); Console.WriteLine("Digite una opcion : ");
                Console.SetCursorPosition(25, 27); opc = int.Parse(Console.ReadLine());

                do
                {
                    Console.WriteLine("Digite una opcion");
                    temporal = Console.ReadLine();
                    if (!Validar.Vacio(temporal))
                        if (Validar.TipoNumero(temporal))
                            EntradaValida = true;

                } while (!EntradaValida);


                switch (opc)
                {
                    case 1:
                        crearEstudiante();
                        break;
                    case 2:
                        listarEstudiante();
                        break;
                    case 3:
                        buscarEstudiante();
                        break;
                    case 4:
                        editarEstudiante();
                        break;
                    case 5:
                        borrarEstudiante();
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;


                }

            } while (opc > 0);
             


             //------Metodos
             
            static void crearEstudiante()
            {
                
                bool Nota1Valido = false;
                bool Nota2Valido = false;
                bool Nota3Valido = false;
                bool NombreValido = false;
                bool CorreoValido = false;
                

                var db = new actividadfinalContext();

                Console.Clear();
                Console.SetCursorPosition(25,9); Console.WriteLine("-----Crear Estudiantes-----");
                Console.SetCursorPosition(25,11); Console.WriteLine("---------------------------");             
                
                
                

                Console.SetCursorPosition(60,14); int cod = int.Parse(Console.ReadLine());

                // validar codigo 

                var Existe = db.Estudiantes.Find(cod);


                if (Existe == null)
                {
                    do
                    {
                        Console.SetCursorPosition(25, 16); Console.Write("Digite El Nombre del Estudiante :");
                        Console.SetCursorPosition(60, 16); string nom = Console.ReadLine();
                        if (!Validar.Vacio(nom))
                            if (Validar.TipoTexto(nom))
                                NombreValido = true;
                    } while (!NombreValido);




                    do
                    {
                        Console.SetCursorPosition(25, 18); Console.Write("Digite El Correo del Estudiante :");
                        Console.SetCursorPosition(60, 18); string cor = Console.ReadLine();
                        if (!Validar.Vacio(cor))
                            if (Validar.TipoNumero(cor))
                                CorreoValido = true;
                    } while (!CorreoValido);


                    do
                    {
                        Console.SetCursorPosition(25, 20); Console.Write("Digite la Nota 1  del Estudiante :");
                        Console.SetCursorPosition(60, 20); string n1 = Console.ReadLine();
                        if (!Validar.Vacio(n1))
                            if (Validar.TipoNumero(n1))
                                Nota1Valido = true;
                        if (Validar.TipoTexto(n1))
                            NombreValido = true;
                    } while (!Nota1Valido);



                    do
                    {
                        Console.SetCursorPosition(25, 20); Console.Write("Digite la Nota 2  del Estudiante :");
                        Console.SetCursorPosition(60, 22); string n2 = Console.ReadLine();
                        if (!Validar.Vacio(n2))
                            if (Validar.TipoNumero(n2))
                                Nota2Valido = true;
                        if (Validar.TipoTexto(n2))
                            NombreValido = true;
                    } while (!Nota2Valido);


                    do
                    {
                        Console.SetCursorPosition(25, 20); Console.Write("Digite la Nota 3  del Estudiante :");
                        Console.SetCursorPosition(60, 24); string n3 = Console.ReadLine();
                        if (!Validar.Vacio(n3))
                            if (Validar.TipoNumero(n3))
                                Nota2Valido = true;
                        if (Validar.TipoTexto(n3))
                            NombreValido = true;
                    } while (!Nota3Valido);


                    Estudiantes myEstudiante = new Estudiantes
                    {
                        
                        
                    };

                    db.Estudiantes.Add(myEstudiante);
                    db.SaveChanges();

                } else
                    

                {
                    Console.SetCursorPosition(30, 30); Console.Write("---El codigo ya existe---");
                    Console.ReadKey();
                }

                   

            }  

                  


                     

            static void listarEstudiante()
            {
                

                 Console.Clear();
                 Console.SetCursorPosition(25, 16); Console.WriteLine("-----Listar Estudiantes-----");

                 Console.ReadKey();

                

                 int y = 5;
              
                    Console.SetCursorPosition(10, 25); Console.Write("Codigo");
                    Console.SetCursorPosition(15, 25); Console.Write("Nombre");
                    Console.SetCursorPosition(20,25); Console.Write("Correo");
                    Console.SetCursorPosition(25, 25); Console.Write("Nota1");
                    Console.SetCursorPosition(30, 25); Console.Write("Nota2");
                    Console.SetCursorPosition(35, 25); Console.Write("Nota3");


                    y++;
                   
                   
                     var db = new actividadfinalContext();

                     var estudiantes = db.Estudiantes.ToList();




                foreach (var myEstudiante in estudiantes)
                {

                        Console.SetCursorPosition(60, 20); Console.Write(myEstudiante.Codigo);
                        Console.SetCursorPosition(60,22); Console.Write(myEstudiante.Nombre);
                        Console.SetCursorPosition(60,24); Console.Write(myEstudiante.Correo);
                        Console.SetCursorPosition(60, 26); Console.Write(myEstudiante.Nota1);
                        Console.SetCursorPosition(60, 28); Console.Write(myEstudiante.Nota2);
                        Console.SetCursorPosition(60, 30); Console.Write(myEstudiante.Nota3);
                        y++;

                }

                
                

            }
            static void buscarEstudiante ()
            {
                var db = new actividadfinalContext();

                string cod;
                bool CodigoValido = false;

                Console.Clear();
                Console.SetCursorPosition(25, 20);Console.WriteLine("-----Buscar Estudiantes-----");

                Console.SetCursorPosition(25, 24); Console.Write("Digite codigo de estudiante que desea buscar: ");
                Console.SetCursorPosition(25, 2); int Cod = int.Parse(Console.ReadLine());

                var Existe = db.Estudiantes.Find(Cod);

                do
                {
                    
                    cod = Console.ReadLine();
                    if (!Validar.Vacio(cod))
                        if (Validar.TipoNumero(cod))
                            CodigoValido = true;
                } while (!CodigoValido);


                if (Existe != null)
                {
                    var myEstudiante = db.Estudiantes.FirstOrDefault(e => e.Codigo == Cod);

                    Console.WriteLine($"{myEstudiante.Codigo} \t { myEstudiante.Nombre} \t { myEstudiante.Correo} \t { myEstudiante.Nota1} \t { myEstudiante.Nota2} \t{ myEstudiante.Nota3}");

                }
                else
                    Console.SetCursorPosition(25, 20); Console.WriteLine("---el codigo no existe---");

                Console.ReadLine();






            }

            static void editarEstudiante()
            {
          
               
                var db = new actividadfinalContext();

                Console.Clear();
                Console.SetCursorPosition(25, 20); Console.WriteLine("-----Editar Estudiante----");

                Console.SetCursorPosition(25, 24); Console.Write("Digite codigo de estudiante que desea buscar ");
                Console.SetCursorPosition(25, 26);  int Cod = int.Parse(Console.ReadLine());

                var Existe = db.Estudiantes.Find(Cod);


                if (Existe != null)
                {
                    var myEstudiante = db.Estudiantes.FirstOrDefault(e => e.Codigo == Cod);

                    Console.SetCursorPosition(25,14); Console.Write(myEstudiante.Codigo);
                    Console.SetCursorPosition(25,16); Console.Write(myEstudiante.Nombre);
                    Console.SetCursorPosition(25,18); Console.Write(myEstudiante.Correo);
                    Console.SetCursorPosition(25,20); Console.Write(myEstudiante.Nota1);
                    Console.SetCursorPosition(25,22); Console.Write(myEstudiante.Nota2);
                    Console.SetCursorPosition(25,24); Console.Write(myEstudiante.Nota3);


                    Console.SetCursorPosition(60,16); string nom = Console.ReadLine();
                    Console.SetCursorPosition(60,18); string cor = Console.ReadLine();
                    Console.SetCursorPosition(60,20); int n1 = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(60,22); int n2 = int.Parse(Console.ReadLine());
                    Console.SetCursorPosition(60,24); int n3 = int.Parse(Console.ReadLine());


                    myEstudiante.Nombre = nom;
                    myEstudiante.Correo = cor;
                    myEstudiante.Nota1 = n1;
                    myEstudiante.Nota2 = n2;
                    myEstudiante.Nota3 = n3;
                    db.SaveChanges();

                    Console.SetCursorPosition(25, 27);  Console.WriteLine("---Los datos se actualizaron correctamente---");



                }
                else
                    Console.SetCursorPosition(25, 27); Console.WriteLine("---el codigo no existe---");

                    Console.ReadLine();
            }




            static void borrarEstudiante()
            {
                var db = new actividadfinalContext();

                Console.Clear();
                Console.SetCursorPosition(25, 20); Console.WriteLine("-----Borrar Estudiante-----");

                Console.SetCursorPosition(25, 22); Console.Write("Digite codigo de estudiante que desea borrar: ");
                Console.SetCursorPosition(25, 24); int Cod = int.Parse(Console.ReadLine());

                var Existe = db.Estudiantes.Find(Cod);


                if (Existe != null)
                {
                    var myEstudiante = db.Estudiantes.FirstOrDefault(e => e.Codigo == Cod);
                    string confirmar = "n";

                    Console.SetCursorPosition(25, 25); Console.Write(" Desea borrar los datos de (myEstudiante.Nombre) s/n ") ;
                    Console.SetCursorPosition(25, 26); confirmar = Console.ReadLine();

                    if (confirmar == "s") {
                        db.Estudiantes.Remove(myEstudiante);
                        db.SaveChanges();
                        Console.SetCursorPosition(25, 27); Console.WriteLine("---Datos borrados con exito---");
                    } else


                        Console.SetCursorPosition(25, 27); Console.WriteLine("---Se cancelo borrar datos---");


                }
                else
                    Console.SetCursorPosition(25, 27); Console.WriteLine("---el codigo no existe---");

                Console.ReadLine();
            }




             static void Marco()
             {
                for (int i = 1; i <= 110; i++)
                {
                    Console.SetCursorPosition(1, i); Console.WriteLine("=");
                    Console.SetCursorPosition(110, i); Console.WriteLine("=");
                }

                for (int i = 1; i <= 25; i++)

                {
                    Console.SetCursorPosition(1, i); Console.WriteLine("║");
                    Console.SetCursorPosition(110, i); Console.WriteLine("║");
                }

                Console.SetCursorPosition(1, 1); Console.WriteLine("╔");
                Console.SetCursorPosition(110, 1); Console.WriteLine("╗");
                Console.SetCursorPosition(1, 25); Console.WriteLine("╚");
                Console.SetCursorPosition(110, 25); Console.WriteLine("╗");



             }






        }





    }




}














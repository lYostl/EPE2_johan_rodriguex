using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SERVICIO_DE_FACTURACION.models;

namespace SERVICIO_DE_FACTURACION.Controllers
{
    public class clientecontrollers : Controller
    {
        public cliente[] Datoscliente = new cliente[]
        {
        new cliente {id= 1,RutCliente = 210687238, nombreCliente = "johann",apellidoCliente = "rodriguez", edadcliente=21,nombreEmpresa = "autos el lautaro",RutEmpresa =23927570,GiroEmpresa = "autos",TotalVentas = 900,MontoDeDineroDeLasVentasHechas = 3400000 ,iva = 1780000,montoMes =3222000 },
        new cliente {id= 2,RutCliente = 210577395, nombreCliente= "benjamin",apellidoCliente = "salas", edadcliente=32,nombreEmpresa = "lapiezes veloses",RutEmpresa =22577256, GiroEmpresa = "lapizes", TotalVentas = 400, MontoDeDineroDeLasVentasHechas = 300000,iva = 1570000,montoMes =2843000, },
        new cliente {id= 3,RutCliente = 224760028, nombreCliente= "martin",apellidoCliente = "gonzales", edadcliente=45,nombreEmpresa = "cocacola", RutEmpresa = 2235524, GiroEmpresa = "bebidas",TotalVentas = 500, MontoDeDineroDeLasVentasHechas = 2540000, iva = 1330000,montoMes =2407000},

        };



        [HttpGet]
        [Route("Empresa")]

        public IActionResult ListarDatos()
        {
            if (Datoscliente != null)
            {

                for (int i = 0; i < Datoscliente.Length; i++)
                {


                    Console.WriteLine(" se encontro", Datoscliente[i]);
                }




                return StatusCode(200, Datoscliente);
            }

            else
            {
                Console.WriteLine("no se registra nada");
                return StatusCode(404);
            }
        }


        [HttpGet]
        [Route("listar/{giroempresa}")]


        public IActionResult ConsoltarPorGiro(int Giroempresa)
        {

            try
            {
                if (Giroempresa != Datoscliente.Length)
                {
                    return StatusCode(200, Datoscliente[Giroempresa - 1]);

                }
                else
                {
                    return StatusCode(400, "nose se encontro ");
                }
            }catch (Exception) { 
            
           
            }
            return StatusCode(200);


        }


        [HttpPost]
        [Route("empresa")]
        public IActionResult CrearEmpresa([FromBody] Empresa empresa)
        {
            try
            {
                if (empresa == null)
                {
                    return BadRequest("La solicitud no contiene datos válidos para la empresa.");
                }





                return Ok("Empresa creada con éxito.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "No se pudo crear la empresa por: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("Empresa/{Id}")]
        public IActionResult EditarEmpresa(int id, [FromBody] Empresa newDatos)
        {
            if (id > 0 && id <= Datoscliente.Length)
            {

                Datoscliente[id - 1].id = newDatos.id;
                Datoscliente[id - 1].nombreCliente = newDatos.nombreCliente;
                Datoscliente[id - 1].apellidoCliente = newDatos.ape_cliente;
                Datoscliente[id - 1].edadcliente = newDatos.Edad;
                Datoscliente[id - 1].RutCliente = newDatos.rut_cliente;
                Datoscliente[id - 1].nombreEmpresa = newDatos.nom_empresa;
                Datoscliente[id - 1].RutEmpresa = newDatos.rut_empresa;
                Datoscliente[id - 1].GiroEmpresa = newDatos.giro_empresa;

                return StatusCode(200, Datoscliente[id - 1]);
            }
            else
            {
                
                Console.WriteLine("no se encontro nada");
                return StatusCode(404);
            }
        }






























        [HttpDelete]
        [Route("empresa/{id}")]

        public IActionResult Delete(int id)
        {
            if (id > 0 && id <= Datoscliente.Length)
            {
                Datoscliente[id - 1] = null;
                return StatusCode(200, Datoscliente);
            }else{

                Console.WriteLine("persona no se encontro");
                return StatusCode(404);
            
            }
            
        }


    }
}






        




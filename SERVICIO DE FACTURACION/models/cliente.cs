namespace SERVICIO_DE_FACTURACION.models
{
    public class cliente
    {

        public int id { get; set; }
        public int RutCliente { get; set; }
        public string nombreCliente { get; set; }

        public string apellidoCliente { get; set; }

        public int edadcliente { get; set; }

        public string nombreEmpresa { get; set; }

        public int RutEmpresa { get; set; }

        public string GiroEmpresa { get; set; }

        public  int TotalVentas { get; set; }

        public int MontoDeDineroDeLasVentasHechas { get; set; }

        public int iva { get; set; }

        public int montoMes { get; set; }


    }
}

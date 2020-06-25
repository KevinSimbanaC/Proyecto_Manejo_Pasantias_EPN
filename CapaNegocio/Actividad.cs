using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
   public  class Actividad
    {
        private int idActividad;
        private DateTime fechaRealizacion;
        private DateTime horaInicio;
        private DateTime horaFin;
        private float numHoras;

        public int IdActividad { get => idActividad; set => idActividad = value; }
        public DateTime FechaRealizacion { get => fechaRealizacion; set => fechaRealizacion = value; }
        public DateTime HoraInicio { get => horaInicio; set => horaInicio = value; }
        public DateTime HoraFin { get => horaFin; set => horaFin = value; }
        public float NumHoras { get => numHoras; set => numHoras = value; }

        public Actividad()
        {
        }

        public Actividad(int idActividad, DateTime fechaRealizacion, DateTime horaInicio, DateTime horaFin, float numHoras)
        {
            this.idActividad = idActividad;
            this.fechaRealizacion = fechaRealizacion;
            this.horaInicio = horaInicio;
            this.horaFin = horaFin;
            this.numHoras = numHoras;
        }

        public override string ToString()
        {
            return this.IdActividad+"";
        }
    }
}

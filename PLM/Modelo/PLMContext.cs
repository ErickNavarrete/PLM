using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data;
using PLM.Clases;

namespace PLM.Modelo
{
    public class PLMContext : DbContext
    {
        //Contexto(Base de datos PLM)
        //@"Data Source=OMARTUAPC;Initial Catalog=PLM;User Id=sa;Password=21128307omar;"
        //@"Data Source="+ ConfigIni.Host +";Initial Catalog=" + ConfigIni.Bd + ";User Id=" + ConfigIni.Id + ";Password=" + ConfigIni.Password + ";")
        //public PLMContext() : base(@"Data Source=" + ConfigIni.Host + ";Initial Catalog=" + ConfigIni.Bd + ";Integrated Security=True;")
        //{

        //}

        public PLMContext() : base(@"Data Source=" + ConfigIni.Host + ";Initial Catalog=" + ConfigIni.Bd + ";User Id=" + ConfigIni.Id + ";Password=" + ConfigIni.Password + ";")
        {

        }

        //Tablas del sistema en base a los modelos creados
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Proceso> Procesos { get; set; }
        public virtual DbSet<Trims> Trims { get; set; }
        public virtual DbSet<Temporadas> Temporadas { get; set; }
        public virtual DbSet<Body> Body { get; set; }
        public virtual DbSet<Inseam> Inseam { get; set; }
        public virtual DbSet<Empaques> Empaques { get; set; }
        public virtual DbSet<ManodeObra> ManodeObra { get; set; }
        public virtual DbSet<Segmentos> Segmentos { get; set; }
        public virtual DbSet<Fit> Fit { get; set; }
        public virtual DbSet<Tareas> Tareas { get; set; }
        public virtual DbSet<TareasThread> TareasThread { get; set; }
        public virtual DbSet<EstilosProduccions> EstilosProduccion { get; set; }
        public virtual DbSet<Segundas> Segundas { get; set; }  
        public virtual DbSet<Category_2> Category_2 { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<BitacoraDeEventos> BitacoraDeEventos { get; set; }
        public virtual DbSet<Presupuestos> Presupuestos { get; set; }
        public virtual DbSet<DiasFeriados> DiasFeriados { get; set; }
        public virtual DbSet<DiasAnticipacion> DiasAnticipacion { get; set; }
        public virtual DbSet<Boms> Boms { get; set; }
        public virtual DbSet<BomsDetails> BomsDetails { get; set; }
        public virtual DbSet<Notificacion> Notificacion { get; set; }
        public virtual DbSet<Hilos> Hilos { get; set; }
        public virtual DbSet<HilosDetails> HilosDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PLMContext, Migrations.Configuration>());            
        }
    }
}

namespace Sistema_MVC_Ticona.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    //agregar estas lineas
    using System.Linq;
    using System.Data.Entity;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        public int persona_id { get; set; }

        [Column("usuario")]
        [Required]
        [StringLength(30)]
        public string usuario1 { get; set; }

        [Required]
        [StringLength(50)]
        public string clave { get; set; }

        [Required]
        [StringLength(45)]
        public string nivel { get; set; }

        [StringLength(250)]
        public string avatar { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Persona Persona { get; set; }

        //Crear el metodo Listar

        public List<Usuario> Listar() //retorna una colleccion
        {
            var usuario = new List<Usuario>();
            try
            {
                //coneccion a la fuente de datos
                using (var db = new Model_Entity_1())
                {
                    //usuario = db.Usuario.ToList();
                    usuario = db.Usuario.Include("Persona").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return usuario;
        }
        //Metodo obtener 
        public Usuario Obtener(int id)//retorna un solo objeto
        {
            var usuario = new Usuario();
            try
            {
                using (var db = new Model_Entity_1())
                {
                    //usuario = db.Usuario.Where(x => x.usuario_id == id)
                    //.SingleOrDefault();
                    usuario = db.Usuario.Include("Persona").Where(x => x.usuario_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return usuario;
        }
        //Metodo Buscar
        public List<Usuario> Buscar(string criterio)//retorna un solo objeto
        {
            var usuario = new List<Usuario>();
            string estadousu = "";
            if (criterio == "Activo") estadousu = "A";
            if(criterio == "Inactivo") estadousu = "I";
            try
            {
                using (var db = new Model_Entity_1())
                {
                    usuario = db.Usuario.Include("Persona")
                                .Where(x => x.Persona.apellido.Contains(criterio) || 
                                x.usuario1.Contains(criterio) ||
                                x.estado == estadousu)
                                 .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return usuario;
        }
        //Metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Entity_1())
                {
                    if (this.usuario_id > 0)//cuando la llave primaria es identity solamante
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Metodo eliminar
        public void Eliminar()
        {
            try
            {
                using (var db = new Model_Entity_1())
                {
                    if (this.usuario_id > 0)
                    {
                        db.Entry(this).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}

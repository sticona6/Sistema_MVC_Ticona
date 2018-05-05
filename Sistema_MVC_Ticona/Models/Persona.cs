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

    [Table("Persona")]
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            Usuario = new HashSet<Usuario>();
        }

        [Key]
        public int persona_id { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(100)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(15)]
        public string celular { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Usuario> Usuario { get; set; }

        //Crear el metodo Listar

        public List<Persona> Listar() //retorna una colleccion
        {
            var persona = new List<Persona>();
            try
            {
                //coneccion a la fuente de datos
                using (var db = new Model_Entity_1())
                {
                    persona = db.Persona.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return persona;
        }
        //Metodo obtener 
        public Persona Obtener(int id)//retorna un solo objeto
        {
            var persona = new Persona();
            try
            {
                using (var db = new Model_Entity_1())
                {
                    persona = db.Persona.Where(x => x.persona_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return persona;
        }
        //Metodo Buscar
        public List<Persona> Buscar(string criterio)//retorna un solo objeto
        {
            var persona = new List<Persona>();
            try
            {
                using (var db = new Model_Entity_1())
                {
                    persona = db.Persona
                                .Where(x => x.nombre.Contains(criterio) ||
                                       x.apellido.Contains(criterio))
                                       .ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return persona;
        }
        //Metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Entity_1())
                {
                    if (this.persona_id > 0)//cuando la llave primaria es identity solamante
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
            catch (Exception ex)
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
                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

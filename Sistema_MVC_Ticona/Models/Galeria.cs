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

    [Table("Galeria")]
    public partial class Galeria
    {
        [Key]
        public int galeria_id { get; set; }

        [Required]
        public int categoria_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Required]
        [StringLength(250)]
        public string imagen { get; set; }

        [Required]
        [StringLength(250)]
        public string thumbail { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Categoria Categoria { get; set; }

        //Crear el metodo Listar

        public List<Galeria> Listar() //retorna una colleccion
        {
            var galeria = new List<Galeria>();
            try
            {
                //coneccion a la fuente de datos
                using (var db = new Model_Entity_1())
                {
                    galeria = db.Galeria.Include("Categoria").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return galeria;
        }
        //Metodo obtener 
        public Galeria Obtener(int id)//retorna un solo objeto
        {
            var galeria = new Galeria();
            try
            {
                using (var db = new Model_Entity_1())
                {
                    galeria = db.Galeria.Include("Categoria").Where(x => x.galeria_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return galeria;
        }
        //Metodo Buscar
        public List<Galeria> Buscar(string criterio)//retorna un solo objeto
        {
            var galeria = new List<Galeria>();
            try
            {
                using (var db = new Model_Entity_1())
                {
                    galeria = db.Galeria.Include("Categoria")
                                .Where(x => x.nombre.Contains(criterio) ||
                                       x.descripcion.Contains(criterio))
                                       .ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return galeria;
        }
        //Metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Entity_1())
                {
                    if (this.galeria_id > 0)//cuando la llave primaria es identity solamante
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
                    if (this.galeria_id > 0)
                    {
                        db.Entry(this).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}

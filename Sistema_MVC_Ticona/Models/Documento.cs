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

    [Table("Documento")]
    public partial class Documento
    {
        [Key]
        public int documento_id { get; set; }

        [Required]
        public int categoria_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [Required]
        [StringLength(4)]
        public string extension { get; set; }

        [Required]
        [StringLength(20)]
        public string tamanio { get; set; }

        [Required]
        [StringLength(250)]
        public string tipo { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        public virtual Categoria Categoria { get; set; }

        //Crear el metodo Listar

        public List<Documento> Listar() //retorna una colleccion
        {
            var documento = new List<Documento>();
            try
            {
                //coneccion a la fuente de datos
                using (var db = new Model_Entity_1())
                {
                    documento = db.Documento.Include("Categoria").ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return documento;
        }
        //Metodo obtener 
        public Documento Obtener(int id)//retorna un solo objeto
        {
            var documento = new Documento();
            try
            {
                using (var db = new Model_Entity_1())
                {
                    documento = db.Documento.Include("Categoria").Where(x => x.documento_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return documento;
        }
        //Metodo Buscar
        public List<Documento> Buscar(string criterio)//retorna un solo objeto
        {
            var documento = new List<Documento>();
            try
            {
                using (var db = new Model_Entity_1())
                {
                    documento = db.Documento.Include("Categoria")
                                .Where(x => x.nombre.Contains(criterio) ||
                                       x.descripcion.Contains(criterio))
                                       .ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return documento;
        }
        //Metodo guardar
        public void Guardar()
        {
            try
            {
                using (var db = new Model_Entity_1())
                {
                    if (this.documento_id > 0)//cuando la llave primaria es identity solamante
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
                    if (this.documento_id > 0)
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

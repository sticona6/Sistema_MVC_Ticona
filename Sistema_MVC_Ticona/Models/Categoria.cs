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

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Documento = new HashSet<Documento>();
            Galeria = new HashSet<Galeria>();
        }

        [Key]
        public int categoria_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string descripcion { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documento> Documento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Galeria> Galeria { get; set; }

        //Crear el metodo Listar

        public List<Categoria> Listar() //retorna una colleccion
        {
            var categoria = new List<Categoria>();
            try
            {
                //coneccion a la fuente de datos
                using (var db = new Model_Entity_1())
                {
                    categoria = db.Categoria.ToList();
                }
            }
            catch (Exception ex) {
                throw;
            }
            return categoria;
        }
        //Metodo obtener 
        public Categoria Obtener(int id)//retorna un solo objeto
        {
            var categoria = new Categoria();
            try {
                using (var db = new Model_Entity_1())
                {
                    categoria = db.Categoria.Where(x => x.categoria_id == id)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex) {

                throw;
            }

            return categoria;
        }
        //Metodo Buscar
        public List<Categoria> Buscar(string criterio)//retorna un solo objeto
        {
            var categoria = new List<Categoria>();
            try
            {
                using (var db = new Model_Entity_1())
                {
                    categoria = db.Categoria
                                .Where(x => x.nombre.Contains(criterio) ||
                                       x.descripcion.Contains(criterio))
                                       .ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return categoria;
        }
        //Metodo guardar
        public void Guardar() {
            try
            {
                using (var db = new Model_Entity_1())
                {
                    if (this.categoria_id > 0)//cuando la llave primaria es identity solamante
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch(Exception ex) {
                throw;
            }
        }
        //Metodo eliminar
        public void Eliminar() {
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

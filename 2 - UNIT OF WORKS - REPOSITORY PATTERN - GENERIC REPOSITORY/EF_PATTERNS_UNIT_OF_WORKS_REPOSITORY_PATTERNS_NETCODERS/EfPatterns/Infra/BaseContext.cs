using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace EfPatterns.Infra
{
    public class BaseContext<T> : DbContext where T : class
    {
        public DbSet<T> DbSet { get; set; }

        public BaseContext() :
            base("EFConnectionString")
        {
            //Caso a base de dados não tenha sido criada, 
            //ao iniciar a aplicação iremos criar
            Database.SetInitializer<BaseContext<T>>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Neste momento não iremos fazer nada, 
            //iremos voltar mais para frente para criar nosso mapeamos dinamicos
            //base.OnModelCreating(modelBuilder);

            //Fazendo o mapeamento com o banco de dados
            //Pega todas as classes que estão implementando a interface IMapping
            //Assim o Entity Framework é capaz de carregar os mapeamentos
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();

            // Varrendo todos os tipos que são mapeamento 
            // Com ajuda do Reflection criamos as instancias 
            // e adicionamos no Entity Framework
            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.Configurations.Add(mappingClass);
            }

            //Agora com a implementação acima nosso Repositório é capaz de identificar 
            //um novo mapeamento e carregá-lo em tempo de execução.
        }

        public virtual void ChangeObjectState(object model, EntityState state)
        {
            //Aqui trocamos o estado do objeto, 
            //facilita quando temos alterações e exclusões
            ((IObjectContextAdapter)this)
                          .ObjectContext
                          .ObjectStateManager
                          .ChangeObjectState(model, state);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.DbSet.ToList();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IEnumerable<T> Where(Expression<Func<T, bool>> expression)
        {
            return this.DbSet.Where(expression);
        }

        public IEnumerable<T> OrderBy(Expression<Func<T, bool>> expression)
        {
            return this.DbSet.OrderBy(expression);
        }
        

    }
}
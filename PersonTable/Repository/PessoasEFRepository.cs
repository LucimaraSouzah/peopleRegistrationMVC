using PersonTable.Models;
using PersonTable.Repository.Context;
using System.Linq;
using System.Collections.Generic;

namespace PersonTable.Repository
{
    public class PessoasEFRepository
    {
        private readonly DataBaseContext context;
        public PessoasEFRepository()
        {
            context = new DataBaseContext();
        }

        public IList<PessoasEF> Listar()
        {
            return context.PessoasEF.ToList();
           
        }

        public PessoasEF Consultar(int Id)
        {
            return context.PessoasEF.Find(Id);
        }


        public void Inserir(PessoasEF pessoasEF)
        {
            context.PessoasEF.Add(pessoasEF);
            context.SaveChanges();
        }

        public void Alterar(PessoasEF pessoasEF)
        {
            context.PessoasEF.Update(pessoasEF);
            context.SaveChanges();
        }

        public void Excluir(int id)
        {
            var pessoasEF = new PessoasEF()
            {
                IdTipo = id
            };

            context.PessoasEF.Remove(pessoasEF);
            context.SaveChanges();
        }

    }
}
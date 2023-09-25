using Microsoft.EntityFrameworkCore;
using GC.Consulta.Domain.Entidade;
using GC.Consulta.Infra.Context;
using GC.Consulta.Infra.Interface;

namespace GC.Consulta.Infra.Repositorio
{

    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        protected readonly DataBaseContext context;

        public EnderecoRepositorio(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<Endereco> BuscarPorId(long id) => await context.Endereco.Where(e => e.Id == id)?.FirstOrDefaultAsync();

        public async Task<Endereco> Salvar(Endereco endereco)
        {
            if (endereco.Id == 0)
            {
                context.Entry(endereco).State = EntityState.Added;
            }
            else
            {
                context.Entry(endereco).State = EntityState.Modified;
            }

            await context.SaveChangesAsync();

            return endereco;
        }
    }
}

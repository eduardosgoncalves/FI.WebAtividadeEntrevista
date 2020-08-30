using System.Collections.Generic;
using FI.AtividadeEntrevista.DAL;
using FI.AtividadeEntrevista.DML;
using FI.AtividadeEntrevista.HLP;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoCliente
    {
        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public long Incluir(Cliente cliente)
        {
            if (!ValidationHelper.ValidateCpf(cliente.CPF)) throw new System.Exception("CPF inválido.");
            if (VerificarExistencia(cliente.CPF)) throw new System.Exception("CPF já existe na base de dados.");
            var cli = new DaoCliente();
            return cli.Incluir(cliente);
        }

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public void Alterar(Cliente cliente)
        {
            var cli = new DaoCliente();

            if (!ValidationHelper.ValidateCpf(cliente.CPF)) throw new System.Exception("CPF inválido.");

            var clis = cli.Consultar(cliente.Id);

            if (clis.CPF != cliente.CPF)
                if (VerificarExistencia(cliente.CPF)) throw new System.Exception("CPF já existe na base de dados.");

            cli.Alterar(cliente);
        }

        /// <summary>
        /// Consulta o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public Cliente Consultar(long id)
        {
            var cli = new DaoCliente();
            var benef = new DaoBeneficiario();

            var cliente = cli.Consultar(id);
            cliente.Beneficiarios.AddRange(benef.Listar(id));
            return cliente;
        }

        /// <summary>
        /// Excluir o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            var cli = new DaoCliente();
            cli.Excluir(id);
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<Cliente> Listar()
        {
            var cli = new DaoCliente();
            var benef = new DaoBeneficiario();

            var clientes = cli.Listar();
            foreach (var cliente in clientes)
                cliente.Beneficiarios.AddRange(benef.Listar(cliente.Id));
            return clientes;
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            var cli = new DaoCliente();
            var benef = new DaoBeneficiario();

            var clientes = cli.Pesquisa(iniciarEm, quantidade, campoOrdenacao, crescente, out qtd);
            foreach (var cliente in clientes)
                cliente.Beneficiarios.AddRange(benef.Listar(cliente.Id));
            return clientes;
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="CPF"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string CPF)
        {
            var cli = new DaoCliente();
            return cli.VerificarExistencia(CPF);
        }
    }
}

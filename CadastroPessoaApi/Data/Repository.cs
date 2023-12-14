using CadastroPessoaApi.ViewModel;
using Dapper;
using System.Data.SqlClient;

namespace CadastroPessoaApi.Data
{
    public class Repository
    {
        string Conexao = @"Server=(localdb)\mssqllocaldb;Database=CadastroPessoas;Trusted_Connection=True;MultipleActiveResultSets=True";
        public IEnumerable<PessoaViewModel> GetAll()
        {
            string query = "Select Top 1000 * FROM Pessoas";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                return con.Query<PessoaViewModel>(query);
            }
        }
        public PessoaViewModel GetById(int PesoasId)
        {
            string query = "Select * from Pessoas Where PesoasId = @PesoasId";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { PesoasId = PesoasId });
            }


        }
        public PessoaViewModel GetFirstName(string PrimeiroNome)
        {
            string query = "Select * from Pessoas Where PrimeiroNome = @PrimeiroNome";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                return con.QueryFirstOrDefault<PessoaViewModel>(query, new { PrimeiroNome = PrimeiroNome });
            }
        }
        public void update(int PessoaId, string PrimeiroNome)
        {
            string query = "update Pessoas Set PrimeiroNome = @PrimeiroNome where PesoasId = @PesoasId ";
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                con.Execute(query, new { PessoaId = PessoaId, PrimeiroNome = PrimeiroNome });
            }

        }
        public string Create(PessoaViewModel pessoa)
        {
            try
            {
                string query = @"
                                    INSET INTO PESSOAS(PRIMEIRONOME,NOMEMEIO, ULTIMONOME, CPF)
                                    Values(@primeironome, @nomemeio,@ultimonome, @CPF)";

                using (SqlConnection con = new SqlConnection(Conexao))
                {
                    con.Execute(query, new
                    {
                        primeiroNome = pessoa.PrimeiroNome,
                        NOMEMEIO = pessoa.NomeMeio,
                        cpf = pessoa.CPF,
                        ULTIMONOME = pessoa.UltimonOme,
                    });
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
                throw ex;
            }
        }
    }
}


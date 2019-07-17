using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DesafioPartnerGroupJorisson.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioPartnerGroupJorisson.Controllers
{
    [Route("api/[controller]")]
    public class PatrimonioController : Controller
    {
        Conexao conec = new Conexao();
        SqlCommand cmd = new SqlCommand();

        // GET: api/<controller>
        [HttpGet]
        public List<Patrimonio> GetPatrimonios()
        {
            List<Patrimonio> Patrimonios = new List<Patrimonio>();

            cmd.CommandText = "select IdPatrimonio, MarcaId, Nome, Descricao, NrTombo from Patrimonio";

            try
            {
                cmd.Connection = conec.conectar();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Patrimonio patr = new Patrimonio();
                    if (reader["IdPatrimonio"] != null)
                        patr.IdPatrimonio = Int32.Parse(reader["IdPatrimonio"].ToString());
                    if (reader["MarcaId"] != null)
                        patr.MarcaId = Int32.Parse(reader["MarcaId"].ToString());
                    if (reader["Nome"] != null)
                        patr.NomePatrimonio = reader["Nome"].ToString();
                    if (reader["Descricao"] != null)
                        patr.DescricaoPatrimonio = reader["Descricao"].ToString();
                    if (reader["NrTombo"] != null)
                        patr.NrTombo = Int32.Parse(reader["NrTombo"].ToString());
                    Patrimonios.Add(patr);
                }

                conec.desconectar();
            }
            catch (Exception e)
            {

            }

            return Patrimonios;
        }

        // GET api/<controller>/5
        [HttpGet("{pIdPatrimonio}")]
        public Patrimonio Get(int pIdPatrimonio)
        {
            Patrimonio patrimonio = new Patrimonio();

            cmd.CommandText = "select IdPatrimonio, MarcaId, Nome, Descricao, NrTombo from Patrimonio where IdPatrimonio = @pIdPatrimonio";
            cmd.Parameters.AddWithValue("@pIdPatrimonio", pIdPatrimonio);

            try
            {
                cmd.Connection = conec.conectar();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["IdPatrimonio"] != null)
                        patrimonio.IdPatrimonio = Int32.Parse(reader["IdPatrimonio"].ToString());
                    if (reader["MarcaId"] != null)
                        patrimonio.MarcaId = Int32.Parse(reader["MarcaId"].ToString());
                    if (reader["Nome"] != null)
                        patrimonio.NomePatrimonio = reader["Nome"].ToString();
                    if (reader["Descricao"] != null)
                        patrimonio.DescricaoPatrimonio = reader["Descricao"].ToString();
                    if (reader["NrTombo"] != null)
                        patrimonio.NrTombo = Int32.Parse(reader["NrTombo"].ToString());
                }

                conec.desconectar();
            }
            catch (Exception e)
            {

            }

            return patrimonio;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Patrimonio pPatrimonioST)
        {
            cmd.CommandText = "Insert into Patrimonio (IdPatrimonio, MarcaId, Nome, Descricao) values (@IdPatrimonio, @MarcaId, @Nome, @Descricao)";

            cmd.Parameters.AddWithValue("@IdPatrimonio", pPatrimonioST.IdPatrimonio);
            cmd.Parameters.AddWithValue("@MarcaId", pPatrimonioST.MarcaId);
            cmd.Parameters.AddWithValue("@Nome", pPatrimonioST.NomePatrimonio);
            cmd.Parameters.AddWithValue("@Descricao", pPatrimonioST.DescricaoPatrimonio);

            try
            {
                cmd.Connection = conec.conectar();

                cmd.ExecuteNonQuery();

                conec.desconectar();
            }
            catch (Exception e)
            {

            }
        }

        // PUT api/<controller>/5
        [HttpPut("{pIdPatrimonioE}")]
        public void Put(int pIdPatrimonioE, [FromBody]Patrimonio pPatrimonioST)
        {
            cmd.CommandText = "update Patrimonio set IdPatrimonio = @IdPatrimonio, MarcaId = @MarcaId, Nome = @Nome, Descricao = @Descricao  where IdPatrimonio = @IdPatrimonioE";

            cmd.Parameters.AddWithValue("@IdPatrimonio", pPatrimonioST.IdPatrimonio);
            cmd.Parameters.AddWithValue("@MarcaId", pPatrimonioST.MarcaId);
            cmd.Parameters.AddWithValue("@Nome", pPatrimonioST.NomePatrimonio);
            cmd.Parameters.AddWithValue("@Descricao", pPatrimonioST.DescricaoPatrimonio);
            cmd.Parameters.AddWithValue("@IdPatrimonioE", pIdPatrimonioE);

            try
            {
                cmd.Connection = conec.conectar();

                cmd.ExecuteNonQuery();

                conec.desconectar();
            }
            catch (Exception e)
            {

            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{pIdPatrimonio}")]
        public void Delete(int pIdPatrimonio)
        {
            cmd.CommandText = "Delete Patrimonio where IdPatrimonio = @IdPatrimonio";
            cmd.Parameters.AddWithValue("@IdPatrimonio", pIdPatrimonio);

            try
            {
                cmd.Connection = conec.conectar();

                cmd.ExecuteNonQuery();

                conec.desconectar();
            }
            catch (Exception e)
            {

            }
        }
    }
}

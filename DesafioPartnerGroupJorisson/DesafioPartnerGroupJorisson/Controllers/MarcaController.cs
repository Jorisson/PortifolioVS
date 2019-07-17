using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DesafioPartnerGroupJorisson.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPartnerGroupJorisson.Controllers
{
    [Route("api/[controller]")]
    public class MarcaController : Controller
    {
        Conexao conec = new Conexao();
        SqlCommand cmd = new SqlCommand();

        // GET: api/Marca
        [HttpGet]
        public async Task<ActionResult<List<Marca>>> GetMarcas()
        {
            List<Marca> Marcas = new List<Marca>();

            cmd.CommandText = "select MarcaId, MarcaNome from Marca";

            try
            {
                cmd.Connection = conec.conectar();
                var reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    Marca mar = new Marca();
                    if (reader["MarcaId"] != null)
                        mar.MarcaId = Int32.Parse(reader["MarcaId"].ToString());
                    if (reader["MarcaNome"] != null)
                        mar.NomeMarca = reader["MarcaNome"].ToString();

                    Marcas.Add(mar);
                }

                conec.desconectar();
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return Marcas;
        }

        // GET api/<controller>/5
        [HttpGet("{pMarcaId}")]
        public async Task<ActionResult<Marca>> GetMarcaID(int pMarcaId)
        {
            Marca marca = new Marca();

            cmd.CommandText = "select MarcaId, MarcaNome from Marca where MarcaId = @pMarcaId";
            cmd.Parameters.AddWithValue("@pMarcaId", pMarcaId);

            try
            {
                cmd.Connection = conec.conectar();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Marca mar = new Marca();
                    if (reader["MarcaId"] != null)
                        marca.MarcaId = Int32.Parse(reader["MarcaId"].ToString());
                    if (reader["MarcaNome"] != null)
                        marca.NomeMarca = reader["MarcaNome"].ToString();
                }

                conec.desconectar();
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return marca;
        }

        // GET api/<controller>/5/Patrimonios
        [HttpGet("{pMarcaId}/Patrimonios")]
        public async Task<ActionResult<List<Patrimonio>>> GetPatrimoniosMarca(int pMarcaId)
        {
            List<Patrimonio> Patrimonios = new List<Patrimonio>();

            cmd.CommandText = "select IdPatrimonio, MarcaId, Nome, Descricao, NrTombo from Patrimonio where MarcaId = @MarcaId";
            cmd.Parameters.AddWithValue("@MarcaId", pMarcaId);

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
                return NotFound();
            }

            return Patrimonios;
        }

        // POST api/Marca
        [HttpPost]
        public void Post([FromBody]Marca pMarca)
        {
            cmd.CommandText = "Insert into Marca (MarcaId, MarcaNome) values (@MarcaId, @MarcaNome)";

            cmd.Parameters.AddWithValue("@MarcaId", pMarca.MarcaId);
            cmd.Parameters.AddWithValue("@MarcaNome", pMarca.NomeMarca);

            try
            {
                cmd.Connection = conec.conectar();

                cmd.ExecuteNonQuery();

                conec.desconectar();
            }
            catch (Exception e){
                
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{pMarcaIdE}")]
        public void Put(int pMarcaIdE, [FromBody]Marca pMarca)
        {
            cmd.CommandText = "update Marca set MarcaId = @MarcaId, MarcaNome = @MarcaNome where MarcaId = @MarcaIdE";

            cmd.Parameters.AddWithValue("@MarcaId", pMarca.MarcaId);
            cmd.Parameters.AddWithValue("@MarcaNome", pMarca.NomeMarca);
            cmd.Parameters.AddWithValue("@MarcaIdE", pMarcaIdE);

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
        [HttpDelete("{pMarcaId}")]
        public void Delete(int pMarcaId)
        {
            cmd.CommandText = "Delete Marca where MarcaId = @pMarcaId";
            cmd.Parameters.AddWithValue("@pMarcaId", pMarcaId);

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

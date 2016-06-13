using System;
using System.Data;
using SQLHelperv2;

namespace DAL
{
    public class DALOndeComprar
    {
        public static DataTable GetCidades()
        {
            string sql = "SELECT DISTINCT cidade FROM Credenciados WHERE liberado = 'S' ORDER BY cidade";
            BD BD = new BD();
            return BD.GetDataTable(sql, null);
        }

        public static DataTable GeSegmentos()
        {
            string sql = "SELECT * FROM Segmentos ORDER BY descricao";
            BD BD = new BD();
            return BD.GetDataTable(sql, null);
        }

        public static DataTable ocGetSegmentos()
        {
            string sql = "SELECT DISTINCT descricao, seg_id from segmentos WHERE seg_id<>0 and APAGADO<>'S' order by descricao";
            BD BD = new BD();
            return BD.GetDataTable(sql, null);
        }

        public static DataTable ocGetcidadeCredenciados(int idSegmento = 0)
        {
            string sql;
            if (idSegmento == 0)
            {
                sql = "SELECT DISTINCT CIDADE FROM CREDENCIADOS WHERE apagado = 'N' and liberado = 'S' AND CIDADE <> '' order by cidade;";
            }
            else
            {
                sql = "select DISTINCT c.cidade, c.seg_id from credenciados AS c WHERE cidade != '' and c.seg_id = " + idSegmento + " AND apagado = 'N' and liberado = 'S' order by cidade ;";
            }
            BD BD = new BD();
            return BD.GetDataTable(sql, null);
        }

        public static DataTable ocGetBairroCredenciados(int idSegmento, bool setouCidade, String cidade = "")// a variável set setouCidade está verificando se o usuário setou cidade ou não
        {
            string sql;
            if (idSegmento == 0)
            {
                if (setouCidade == true)
                {
                    sql = "select distinct bairro from credenciados where cidade like'%" + cidade + "%' AND apagado = 'N' and liberado = 'S' order by bairro";
                }
                else
                {
                    sql = "SELECT cred_id, (CASE WHEN (fantasia = '' OR fantasia IS NULL) THEN nome ELSE fantasia END) AS fantasia FROM Credenciados WHERE apagado = 'N' and liberado = 'S' order by bairro";
                }
            }
            else
            {
                if (setouCidade == true)
                {
                    sql = "select distinct c.bairro from credenciados as c join segmentos as s on c.seg_id = " + idSegmento + " and cidade like'%" + cidade + "%' AND c.apagado = 'N' and c.liberado = 'S' order by bairro";
                }
                else
                {
                    sql = "SELECT cred_id, (CASE WHEN (fantasia = '' OR fantasia IS NULL) THEN nome ELSE fantasia END) AS fantasia FROM Credenciados WHERE apagado = 'N' and liberado = 'S' and seg_id = " + idSegmento + " order by bairro;";
                }
            }
            BD BD = new BD();
            return BD.GetDataTable(sql, null);
        }

        public static DataTable ocFiltroPorBairro(int segId, bool setouBairro, string cidade, string bairro = "")
        {
            string sql;
            if (segId != 0)
            {
                if (setouBairro == true)
                {
                    sql = "SELECT fantasia, descricao, endereco, numero, bairro, cidade, estado, telefone1 FROM Credenciados, segmentos WHERE Credenciados.apagado = 'N' and Credenciados.liberado = 'S' AND segmentos.seg_id = " + segId + " and cidade = '" + cidade + "' and bairro = '" + bairro + "' and segmentos.seg_id = credenciados.seg_id order by descricao, fantasia";
                }
                else
                {
                    sql = "SELECT fantasia, descricao, endereco, numero, bairro, cidade, estado, telefone1 FROM Credenciados, segmentos WHERE Credenciados.apagado = 'N' and Credenciados.liberado = 'S' AND segmentos.seg_id = " + segId + " and cidade = '" + cidade + "' and segmentos.seg_id = credenciados.seg_id order by descricao, fantasia";
                }
            }
            else
            {
                if (setouBairro == true)
                {
                    sql = "SELECT fantasia, descricao, endereco, numero, bairro, cidade, estado, telefone1 FROM Credenciados, segmentos Where cidade = '" + cidade + "' AND bairro = '" + bairro + "' AND Credenciados.apagado = 'N' and Credenciados.liberado = 'S' and segmentos.seg_id = credenciados.seg_id order by descricao, fantasia";
                }
                else
                {
                    sql = "SELECT fantasia, descricao, endereco, numero, bairro, cidade, estado, telefone1 FROM Credenciados, segmentos Where cidade = '" + cidade + "' AND Credenciados.apagado = 'N' and Credenciados.liberado = 'S' and segmentos.seg_id = credenciados.seg_id order by descricao, fantasia";
                }
            }

            BD BD = new BD();
            return BD.GetDataTable(sql, null);
        }

        public static DataTable ocListaDadosCredenciados(int id_segmento)
        {
            string sql;
            if (id_segmento == 0)
            {
                //sql = "SELECT * FROM credenciados WHERE APAGADO = 'N' AND LIBERADO = 'S'";
                sql = "SELECT fantasia, descricao, endereco, numero, bairro, cidade, estado, telefone1 FROM credenciados, segmentos WHERE Credenciados.liberado = 'S' AND Credenciados.apagado = 'N' and segmentos.seg_id = credenciados.seg_id order by descricao, fantasia";
            }
            else
            {
                //sql = "SELECT nome, fantasia, endereco, numero, bairro, cidade, estado, telefone1 FROM credenciados WHERE liberado = 'S' AND apagado = 'N'AND seg_id = " + id_segmento + ";";
                sql = "SELECT fantasia, descricao, endereco, numero, bairro, cidade, estado, telefone1 FROM credenciados, segmentos WHERE Credenciados.liberado = 'S' AND Credenciados.apagado = 'N' AND segmentos.seg_id = " + id_segmento + " and segmentos.seg_id = credenciados.seg_id order by descricao, fantasia";
            }
            BD BD = new BD();
            return BD.GetDataTable(sql, null);
        }
        public static int CountCredenciados(bool pesqSeg, string cidade, string segmento, string fantasia)
        {
            string sql = "SELECT COUNT (*) FROM Credenciados ";

            if (pesqSeg)
            {
                sql += " WHERE liberado = 'S'";
                if (cidade != "")
                    sql += " AND cidade = '" + cidade + "'";
                sql += " AND seg_id = " + segmento;
            }
            else
                sql += " WHERE liberado = 'S' AND  fantasia LIKE '%" + fantasia.ToUpper() + "%'";

            BD BD = new BD();
            DataTable tabela = BD.GetDataTable(sql, null);

            return Convert.ToInt32(tabela.Rows[0][0].ToString());
        }

        public static DataTable GetCredenciados(int page, int start, bool pesqSeg, string cidade, string segmento, string fantasia)
        {
            string sql = "SELECT FIRST " + page + " SKIP " + start + " cred_id, (CASE WHEN (fantasia = '' OR fantasia IS NULL) THEN nome ELSE fantasia END) AS fantasia ";
            sql += "FROM Credenciados ";

            if (pesqSeg)
            {
                sql += "WHERE liberado = 'S'";
                if (cidade != "")
                    sql += " AND cidade = '" + cidade + "'";
                sql += " AND seg_id = " + segmento;
            }
            else
                sql += " WHERE liberado = 'S' AND fantasia LIKE '%" + fantasia.ToUpper() + "%'";

            BD BD = new BD();
            return BD.GetDataTable(sql, null);
        }

        public static DataTable GetDetalhes(string id)
        {
            string sql = "SELECT bairro, cep, cred_id, cidade, contato, email, endereco, ";
            sql += " estado, fantasia, fax, homepage, nome, telefone1, telefone2 ";
            sql += " FROM Credenciados ";
            sql += " WHERE cred_id = @Id";

            SqlParamsList ps = new SqlParamsList();
            ps.Add(new Fields("Id", id));

            BD BD = new BD();
            return BD.GetDataTable(sql, ps);
        }
    }
}
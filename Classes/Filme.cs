namespace Acervo.Filmes
{
    public class Filme : EntidadeBase
    {
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descrição {get; set;}
        private int Ano {get; set;}
        private ClassIndicativa ClassIndicativa{get; set;}

        private bool Excluido {get; set;}
        private  Assistido Assistido{get; set;}

        //Implantação dos metodos
        public Filme(int id, Genero genero, string titulo, string descrição, int ano, ClassIndicativa classIndicativa, Assistido assistido)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descrição = descrição;
            this.Ano = ano;
            this.ClassIndicativa = classIndicativa;
            this.Assistido = assistido;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genero:" + this.Genero + Environment.NewLine;
            retorno += "Titulo:" + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descrição + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano + Environment.NewLine;
            retorno += "Classe indicativa: " + this.ClassIndicativa + Environment.NewLine;
            retorno += "Já assistiu? " + this.Assistido + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;
            return retorno;

        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        
        internal int retornaId()
        {
            return this.Id;
        }

           internal bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}


using System;
using Godot;
using BibliotecaViva.DTO;

namespace BibliotecaViva.BLL.Utils
{
    public static class ImportadorDeImagensUtil
    {
        public static long Counter { get; set; } = 0;
        public static Texture BuscarImagem(string nomeImagem, string formato, string caminho)
        {
            var imagem = new Image();
            var texturaDaImagem = new ImageTexture();
            var caminhoComFormato = caminho + nomeImagem + "." + formato;
            var caminhoImport = caminhoComFormato + ".import";

            imagem.Load(caminhoComFormato);
            texturaDaImagem.CreateFromImage(imagem);
            LimparArquivosTemporarios(caminhoComFormato, caminhoImport);
            
            return texturaDaImagem;
        }
        private static void LimparArquivosTemporarios(string caminhoComFormato, string caminhoImport)
        {
            if (System.IO.File.Exists(caminhoComFormato))
                System.IO.File.Delete(caminhoComFormato);
            if (System.IO.File.Exists(caminhoImport))
                System.IO.File.Delete(caminhoImport);
        }
        public static Texture GerarImagem(string nomeImagem, string formato, string base64)
        {
            Counter++;
            nomeImagem += Counter;
            if(!System.IO.Directory.Exists("TEMP"))
                System.IO.Directory.CreateDirectory("TEMP");
            var caminho = "./TEMP/";
            System.IO.File.WriteAllBytes(caminho + nomeImagem + "." + formato, Convert.FromBase64String(base64));
            return BuscarImagem(nomeImagem, formato, caminho);
        }
        public static string ObterBase64(string nomeImagem, string formato, string caminho)
        {
            return ObterBase64(caminho + nomeImagem, formato);
        }
        public static string ObterBase64(string caminho, string formato)
        {
            return ObterBase64(caminho + formato);
        }
        public static string ObterBase64(string caminho)
        {
            return System.Convert.ToBase64String(System.IO.File.ReadAllBytes(caminho));
        }
    }
}
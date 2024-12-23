﻿using System.Text.Json.Serialization;

namespace APIVisionary.Models
{
    public class UsuariosModel
    {
        public int Id { get; set; }
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        public DateTime NascDate { get; set; }
        public DateTime DataCriationAccount { get; set; } = DateTime.Now;

        [JsonIgnore]
        public ICollection<PlaylistVideos> PlaylistUser { get; set; }

        [JsonPropertyName("Meus vídeos")]
        public ICollection<ConteudoModel> VideosPublicados { get; set; }
    }
}

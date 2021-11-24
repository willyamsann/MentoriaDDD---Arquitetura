using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder) 
        {
            builder.ToTable("Clientes"); // NOME DA TABELA

            builder.HasKey(prop => prop.Id); // CHAVE PRIMARIA 

            builder.Property(prop => prop.Cpf)
                .IsRequired() // NOT NULL
                .HasColumnName("Cpf") //NOME DA COLUNA
                .HasColumnType("varchar(11)"); //TAMANHO DA COLUNA
        }
    }
}

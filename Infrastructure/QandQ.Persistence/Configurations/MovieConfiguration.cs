using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QandQ.Application.Features.Movies.Dtos;
using QandQ.Domain.Entities;

namespace QandQ.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(p => p.Id);
            builder.Property(p => p.original_language);
            builder.Property(p => p.original_title);
            builder.Property(p => p.overview);
            builder.Property(p => p.popularity);
            builder.Property(p => p.poster_path);
            builder.Property(p => p.release_date);
            builder.Property(p => p.title);
            builder.Property(p => p.video);
            builder.Property(p => p.vote_average);
            builder.Property(p => p.vote_count);
        }
    }
}

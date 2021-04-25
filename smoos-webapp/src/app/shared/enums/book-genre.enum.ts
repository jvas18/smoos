enum MovieGenre{
    Action = 'Action',
    Adventure = 'Adventure',
    Fantasy =  'Fantasy',
    Scifi = 'Scifi',
    Drama = 'Drama',
    Biography = 'Biography',
    Romance = 'Romance',
    Musical = 'Musical',
    Comedy = 'Comedy',
    Horror = 'Horror',
    Romcom = 'Romcom'
}
const allGenres = (): any[] => [
    { value: MovieGenre.Action, description: 'Ação' },
    { value: MovieGenre.Adventure, description: 'Aventura' },
    { value: MovieGenre.Fantasy, description: 'Fantasia' },
    { value: MovieGenre.Scifi, description: 'Ficção Científica' },
    { value: MovieGenre.Drama, description: 'Drama' },
    { value: MovieGenre.Biography, description: 'Biografia' },
    { value: MovieGenre.Musical, description: 'Musical' },
    { value: MovieGenre.Comedy, description: 'Comédia' },
    { value: MovieGenre.Horror, description: 'Terror' },
    { value: MovieGenre.Romcom, description: 'Comédia Romântica' }

];

export {MovieGenre, allGenres};


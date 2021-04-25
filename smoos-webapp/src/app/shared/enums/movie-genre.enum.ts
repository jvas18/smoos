enum BookGenre{
    Action = 'Action',
    Adventure = 'Adventure',
    Fantasy =  'Fantasy',
    Scifi = 'Scifi',
    Drama = 'Drama',
    Biography = 'Biography',
    Romance = 'Romance',
    Comedy = 'Comedy',
    Horror = 'Horror',
    Romcom = 'Romcom'
}
const allGenres = (): any[] => [
    { value: BookGenre.Action, description: 'Ação' },
    { value: BookGenre.Adventure, description: 'Aventura' },
    { value: BookGenre.Fantasy, description: 'Fantasia' },
    { value: BookGenre.Scifi, description: 'Ficção Científica' },
    { value: BookGenre.Drama, description: 'Drama' },
    { value: BookGenre.Biography, description: 'Biografia' },
    { value: BookGenre.Comedy, description: 'Comédia' },
    { value: BookGenre.Horror, description: 'Terror' },
    { value: BookGenre.Romcom, description: 'Comédia Romântica' }

];

export {BookGenre, allGenres};


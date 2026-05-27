import type { Category, RealEstate } from '../types';

export const mockCategories: Category[] = [
  { id: 1, megnevezes: 'Ház' },
  { id: 2, megnevezes: 'Lakás' },
  { id: 3, megnevezes: 'Építési telek' },
  { id: 4, megnevezes: 'Garázs' },
  { id: 5, megnevezes: 'Mezőgazdasági terület' },
  { id: 6, megnevezes: 'Ipari ingatlan' }
];

export const mockOffers: RealEstate[] = [
  {
    id: 1,
    kategoriaId: 1,
    kategoriaNev: 'Ház',
    leiras: 'Kertvárosi részén, egyszintes házat kínálunk nyugodt környezetben, nagy telken.',
    hirdetesDatuma: '2022.03.14',
    tehermentes: true,
    kepUrl: 'https://cdn.jhmrad.com/wp-content/uploads/three-single-storey-houses-elegance-amazing_704000.jpg'
  },
  {
    id: 2,
    kategoriaId: 1,
    kategoriaNev: 'Ház',
    leiras: 'Belvárosi környezetben, árnyékos helyen kis méretű családi ház eladó. Tömegközlekedéssel könnyen megközelíthető.',
    hirdetesDatuma: '2022.03.21',
    tehermentes: true,
    kepUrl: 'https://www.westsideseattle.com/sites/default/files/styles/news_teaser/public/images/archive/ballardnewstribune.com/content/articles/2008/11/21/features/columnists/column07.jpg?itok=wMrlOwFU'
  },
  {
    id: 3,
    kategoriaId: 2,
    kategoriaNev: 'Lakás',
    leiras: 'Kétszintes berendezett lakás a belvárosban kiadó.',
    hirdetesDatuma: '2022.03.17',
    tehermentes: true,
    kepUrl: 'https://images.unsplash.com/photo-1606074280798-2dabb75ce10c?ixlib=rb-1.2.1&auto=format&fit=crop&w=735&q=80'
  }
];
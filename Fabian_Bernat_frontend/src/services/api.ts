import type { Category, NewRealEstate, RealEstate } from '../types';
import { mockCategories, mockOffers } from '../data/mockData';

const STORAGE_KEY = 'mockOffers';

function getStoredOffers(): RealEstate[] {
  const stored = localStorage.getItem(STORAGE_KEY);
  return stored ? JSON.parse(stored) : mockOffers;
}

function saveStoredOffers(offers: RealEstate[]) {
  localStorage.setItem(STORAGE_KEY, JSON.stringify(offers));
}

export async function getCategories(): Promise<Category[]> {
  try {
    const res = await fetch('/api/kategoriak');
    if (!res.ok) throw new Error();
    return await res.json();
  } catch {
    return mockCategories;
  }
}

export async function getOffers(): Promise<RealEstate[]> {
  try {
    const res = await fetch('/api/ingatlan');
    if (!res.ok) throw new Error();
    return await res.json();
  } catch {
    return getStoredOffers();
  }
}

export async function createOffer(data: NewRealEstate): Promise<RealEstate> {
  try {
    const res = await fetch('/api/ujingatlan', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(data)
    });

    if (!res.ok) throw new Error();
    return await res.json();
  } catch {
    const offers = getStoredOffers();
    const category = mockCategories.find(c => c.id === data.kategoriaId);

    const newOffer: RealEstate = {
      id: Math.max(...offers.map(o => o.id), 0) + 1,
      kategoriaId: data.kategoriaId,
      kategoriaNev: category?.megnevezes ?? '',
      leiras: data.leiras,
      hirdetesDatuma: data.hirdetesDatuma.replaceAll('-', '.'),
      tehermentes: data.tehermentes,
      kepUrl: data.kepUrl
    };

    saveStoredOffers([...offers, newOffer]);
    return newOffer;
  }
}
import { useEffect, useState } from 'react';
import { Table } from 'react-bootstrap';
import type { RealEstate } from '../types';
import { getOffers } from '../services/api';

export default function OffersPage() {
  const [offers, setOffers] = useState<RealEstate[]>([]);

  useEffect(() => {
    getOffers().then(setOffers);
  }, []);

  return (
    <main className="container page-container py-4">
      <h1 className="text-center mb-4">Ajánlataink</h1>

      <Table responsive bordered className="offers-table align-middle">
        <thead>
          <tr>
            <th>Kategória</th>
            <th>Leírás</th>
            <th>Hirdetés dátuma</th>
            <th>Tehermentes</th>
            <th>Fénykép</th>
          </tr>
        </thead>

        <tbody>
          {offers.map(offer => (
            <tr key={offer.id}>
              <td>{offer.kategoriaNev}</td>
              <td>{offer.leiras}</td>
              <td>{offer.hirdetesDatuma}</td>
              <td className="text-success fw-semibold">
                {offer.tehermentes ? 'Igen' : 'Nem'}
              </td>
              <td>
                <img src={offer.kepUrl} alt={offer.kategoriaNev} className="offer-img" />
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </main>
  );
}
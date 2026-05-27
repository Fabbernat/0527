import { useEffect, useState, type FormEvent } from 'react';
import { Button, Form } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import type { Category } from '../types';
import { createOffer, getCategories } from '../services/api';

function todayIso() {
  return new Date().toISOString().split('T')[0];
}

export default function NewAdPage() {
  const navigate = useNavigate();

  const [categories, setCategories] = useState<Category[]>([]);
  const [kategoriaId, setKategoriaId] = useState('');
  const [leiras, setLeiras] = useState('');
  const [hirdetesDatuma] = useState(todayIso());
  const [tehermentes, setTehermentes] = useState(true);
  const [kepUrl, setKepUrl] = useState('');

  useEffect(() => {
    getCategories().then(setCategories);
  }, []);

  async function handleSubmit(e: FormEvent) {
    e.preventDefault();

    await createOffer({
      kategoriaId: Number(kategoriaId),
      leiras,
      hirdetesDatuma,
      tehermentes,
      kepUrl
    });

    navigate('/offers');
  }

  return (
    <main className="container page-container py-4">
      <h1 className="text-center mb-4">Új hirdetés elküldése</h1>

      <Form className="newad-form mx-auto" onSubmit={handleSubmit}>
        <Form.Group className="mb-3">
          <Form.Label>Ingatlan kategóriája</Form.Label>
          <Form.Select
            value={kategoriaId}
            onChange={e => setKategoriaId(e.target.value)}
            required
          >
            <option value="">Kérem válasszon</option>
            {categories.map(category => (
              <option key={category.id} value={category.id}>
                {category.megnevezes}
              </option>
            ))}
          </Form.Select>
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Hirdetés dátuma</Form.Label>
          <Form.Control type="date" value={hirdetesDatuma} readOnly />
        </Form.Group>

        <Form.Group className="mb-3">
          <Form.Label>Ingatlan leírása</Form.Label>
          <Form.Control
            as="textarea"
            rows={4}
            value={leiras}
            onChange={e => setLeiras(e.target.value)}
            required
          />
        </Form.Group>

        <Form.Check
          className="mb-3"
          label="Tehermentes ingatlan"
          checked={tehermentes}
          onChange={e => setTehermentes(e.target.checked)}
        />

        <Form.Group className="mb-3">
          <Form.Label>Fénykép az ingatlanról</Form.Label>
          <Form.Control
            type="url"
            value={kepUrl}
            onChange={e => setKepUrl(e.target.value)}
            required
          />
        </Form.Group>

        <div className="text-center">
          <Button type="submit" className="px-5">
            Küldés
          </Button>
        </div>
      </Form>
    </main>
  );
}
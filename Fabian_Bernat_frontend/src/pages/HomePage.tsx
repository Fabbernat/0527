import { Link } from 'react-router-dom';
import bg from '../assets/real-estate-agent.png';

export default function HomePage() {
  return (
    <main
      className="home-page"
      style={{ backgroundImage: `url(${bg})` }}
    >
      <h1>Á.L.B. Ingatlanügynöség</h1>

      <div className="home-buttons">
        <Link to="/offers" className="btn btn-primary">
          Nézze meg kínálatunkat!
        </Link>

        <Link to="/newad" className="btn btn-primary">
          Hirdessen nálunk!
        </Link>
      </div>
    </main>
  );
}
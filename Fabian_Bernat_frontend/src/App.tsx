import { useState } from 'react'
import './App.css'
import { Navigate, BrowserRouter, Routes, Route } from 'react-router'
import HomePage from './pages/HomePage'
import NewAdPage from './pages/NewAdPage'
import OffersPage from './pages/OffersPage'

function App() {
  const [count, setCount] = useState(0)

  return (
    <BrowserRouter>
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/offers" element={<OffersPage />} />
      <Route path="/newad" element={<NewAdPage />} />
      <Route path="*" element={<Navigate to="/" />} />
    </Routes>
    </BrowserRouter>
  )
}

export default App

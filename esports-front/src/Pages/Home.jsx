import { useState } from 'react'
import CampeonatoModal from '../Components/CampeonatoModal'
import EquipeModal from '../Components/EquipeModal'
import './Home.css'

export default function Home() {
  const [showCampeonato, setShowCampeonato] = useState(false)
  const [showEquipe, setShowEquipe] = useState(false)

  return (
    <div className="container">
      <h1>Gerenciador de Esportes</h1>

      <div className="button-container">
        <button onClick={() => setShowCampeonato(true)}>Criar Campeonato</button>
        <button onClick={() => setShowEquipe(true)}>Criar Equipe</button>
      </div>

      <CampeonatoModal open={showCampeonato} onClose={() => setShowCampeonato(false)} />
      <EquipeModal open={showEquipe} onClose={() => setShowEquipe(false)} />
    </div>
  )
}
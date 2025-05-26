import { useState } from 'react'
import './CampeonatoModal.css'

export default function CampeonatoModal({ open, onClose }) {
  const [nome, setNome] = useState('')
  const [data, setData] = useState('')

  if (!open) return null

  const handleSubmit = async (e) => {
    e.preventDefault()

    await fetch('http://localhost:5000/api/Campeonato', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ nome, data }),
    })

    setNome('')
    setData('')
    onClose()
  }

  return (
    <div className="modal-background">
      <div className="modal">
        <h2>Novo Campeonato</h2>
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            placeholder="Nome"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
            required
          />
          <input
            type="date"
            value={data}
            onChange={(e) => setData(e.target.value)}
            required
          />
          <div className="modal-buttons">
            <button type="button" onClick={onClose} className="cancel">Cancelar</button>
            <button type="submit">Criar</button>
          </div>
        </form>
      </div>
    </div>
  )
}
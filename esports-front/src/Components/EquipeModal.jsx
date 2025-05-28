import { useState } from 'react'
import './EquipeModal.css'

export default function EquipeModal({ open, onClose }) {
  const [nome, setNome] = useState('')
  const [participantes, setParticipantes] = useState([''])

  if (!open) return null

  const handleSubmit = async (e) => {
    e.preventDefault()

    const equipe = {
      nome,
      participantes: participantes.map(p => ({ nome: p }))
    }

    await fetch('http://localhost:5000/api/Equipe', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(equipe),
    })

    setNome('')
    setParticipantes([''])
    onClose()
  }

  const handleChange = (index, value) => {
    const novaLista = [...participantes]
    novaLista[index] = value
    setParticipantes(novaLista)
  }

  const addParticipante = () => {
    if (participantes.length < 5) {
      setParticipantes([...participantes, ''])
    }
  }

  return (
    <div className="modal-background">
      <div className="modal">
        <h2>Nova Equipe</h2>
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            placeholder="Nome da Equipe"
            value={nome}
            onChange={(e) => setNome(e.target.value)}
            required
          />

          {participantes.map((p, i) => (
            <input
              key={i}
              type="text"
              placeholder={`Participante ${i + 1}`}
              value={p}
              onChange={(e) => handleChange(i, e.target.value)}
              required
            />
          ))}

          {participantes.length < 5 && (
            <button type="button" onClick={addParticipante} className="add-button">
              + Adicionar Participante
            </button>
          )}

          <div className="modal-buttons">
            <button type="button" onClick={onClose} className="cancel">Cancelar</button>
            <button type="submit">Criar</button>
          </div>
        </form>
      </div>
    </div>
  )
}
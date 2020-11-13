import React from 'react'
import { MdDelete } from 'react-icons/md'

function Item({ item, handleDelete }) {
    const { id, name, price } = item;
    return (
        <li className="item">
            <div className="info">
                <span className="expense">{name}</span>
                <span>${price}</span>
            </div>
            <div>
                <button className="clear-btn" onClick={() => handleDelete(id)} aria-label="delete button">
                    <MdDelete />
                </button>
            </div>
        </li>
    )
}

export default Item
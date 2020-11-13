import React from 'react'
import { MdSend } from "react-icons/md"
import Select from 'react-select'

function Form({ name, amount, category, list, handleName, handleAmount, handleCategory, handleSubmit, edit }) {

    var options = list.map(v => ({ value: v.id, label: v.name }));

    return (
        <form onSubmit={handleSubmit} >
            <div className="form-center">
                <div className="form-group">
                    <label htmlFor="Name">Item Name</label>
                    <input value={name} type="text" className="form-control" onChange={handleName} placeholder="e.g TV" id="name" name="name" />
                </div>
                <div className="form-group">
                    <label htmlFor="Amount">Amount</label>
                    <input value={amount} onChange={handleAmount} type="text" className="form-control" placeholder="e.g 100" id="amount" name="amount" />
                </div>
                <div className="form-group">
                    <label htmlFor="Category">Categories</label>
                    <Select onChange={handleCategory} className="form-select" value={category} options={options}>
                    </Select>
                </div>
            </div>
            <button type="submit" className="btn">
                {edit ? "Edit" : "Add"}
                <MdSend className="btn-icon" /></button>
        </form>
    )
}

export default Form
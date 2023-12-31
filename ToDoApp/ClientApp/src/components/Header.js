﻿import React, { Component, useState } from 'react';
import { FiCalendar, FiPlusCircle } from "react-icons/fi";
import AddTaskModal from './core/tasks/add/AddTaskModal';

function Header(props){

    const [openAddTaskModal, setOpenAddTaskModal] = useState(false);

    function toggleAddTaskModal() {
        setOpenAddTaskModal(!openAddTaskModal);
    }

    function handleChangeDate(event) {
        props.setDate(event.target.value);
    }

    return (
        <div className="h-[100px] w-full justify-between items-center flex px-4 font-bold fixed top-0 left-0 right-0 bg-white">
            <div className="w-[200px] flex items-center select-none cursor-default text-2xl">
                <input className="text-black" type="date" defaultValue={props.date} onChange={handleChangeDate} /> <FiCalendar className="ml-4" />
            </div>
            <div className="text-3xl">
                <h1>"ToDo" App</h1>
            </div>
            <div className="w-[200px] text-2xl flex justify-end">
                <button className="bg-blue-600 py-2 px-4 flex items-center text-white rounded" onClick={() => setOpenAddTaskModal(true)}>Add <FiPlusCircle className="ml-4" /></button>
                <AddTaskModal open={openAddTaskModal} setOpen={setOpenAddTaskModal} />
            </div>
        </div>
    );
}

export default Header;

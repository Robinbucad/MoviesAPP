import './App.css'
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import HomePage from './Pages/HomePage';
import CreateMoviePage from './Pages/CreateMovie';


function App() {

  return (
    
    <div >
        <BrowserRouter>
          <Routes>
            <Route path='/' element={<HomePage/>}></Route>
            <Route path='/CreateMovie' element={<CreateMoviePage/>}></Route>
          </Routes>
        </BrowserRouter>
    </div>

  )
}

export default App;
